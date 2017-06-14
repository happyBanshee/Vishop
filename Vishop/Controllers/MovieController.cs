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

        public ActionResult AllMovies()
        {
            List<Movie> movie = _context.Movies.Include(c => c.Genre).ToList();

            //var viewModel = new RandomMovieViewModel {
            //    Movie = movie,
            //    Genres = _context.Genres.Include(c=>c.name).ToList()
               
            //};

            return View(movie);
        }
        [Route("movie/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.id == id);

            return View(movie);
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.id == id);

            if(movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieViewModel() {
                Movie = movie,
                Genre = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieViewModel() { Genre = genres };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(MovieViewModel mov)
        {
            if(mov.Movie.id == 0)
            {
                mov.Movie.addedDate = DateTime.Now;
                _context.Movies.Add(mov.Movie);
            } else
            {
                var movieInDb = _context.Movies.Single(m => m.id == mov.Movie.id);

                movieInDb.name = mov.Movie.name;
                movieInDb.releaseDate = mov.Movie.releaseDate;
                movieInDb.genresId = mov.Movie.genresId;
                movieInDb.numbeInStock = mov.Movie.numbeInStock;
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