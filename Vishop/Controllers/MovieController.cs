using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vishop.Models;
using Vishop.ViewModels;
using System.Data.Entity;


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
            List<Movie> movie  = _context.Movies.ToList();

            var viewModel = new RandomMovieViewModel {
                Movie = movie
            };

            return View(viewModel);
        }
        [Route("movie/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m=>m.genre).SingleOrDefault(c => c.id == id);

            return View(movie);
        }


    }
}