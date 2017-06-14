using System;
using System.Collections.Generic;
using Vishop.Models;

namespace Vishop.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { set; get; }
        public IEnumerable<Genres> Genre { set; get; }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}