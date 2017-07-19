using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vishop.Models;
using Vishop.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;
//using System.Data.SqlClient;


namespace Vishop.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            // List<Movie> movie = _context.Movies.Include(c => c.Genre).ToList();

            if(User.IsInRole(RoleName.CanManageMovies))
                //return View(movie);
                return View("List");


            return View("ReadOnlyList");
        }
        [Route("movie/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieViewModel(movie) {

                Genre = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieViewModel() {
                Genre = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie mov)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(mov) {

                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if(mov.Id == 0)
            {
                mov.AddedDate = DateTime.Now;
                _context.Movies.Add(mov);
            } else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == mov.Id);

                movieInDb.Name = mov.Name;
                movieInDb.ReleaseDate = mov.ReleaseDate;
                movieInDb.GenresId = mov.GenresId;
                movieInDb.NumberInStock = mov.NumberInStock;
            }

            try
            {
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("AllMovies", "Movie");
        }
    }
}