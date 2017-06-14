﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vishop.Models;


namespace Vishop.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movie> Movie { get; set; }
        public List<Customer> Customer { get; set; }
        public List<Genres> Genres { get; set; }

    }
}