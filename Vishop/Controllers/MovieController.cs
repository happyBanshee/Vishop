using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vishop.Models;
using Vishop.ViewModels;

namespace Vishop.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movies
        public ActionResult AllMovies()
        {
            var movie = new List<Movie> {
                new Movie { name ="Stepford wives"},
                new Movie { name ="Dark Tower"}
            };

            var viewModel = new RandomMovieViewModel {
                Movie = movie
            };

            return View(viewModel);
        }
    }
}