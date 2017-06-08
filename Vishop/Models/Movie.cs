using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vishop.Models
{
    public class Movie
    {
        public int id { set; get; }
        public string name { set; get; }
       // [Required]
        public Genres genre { set; get; }
       public int genresId { set; get; }
        [Required]
        public DateTime releaseDate { set; get; }
        [Required]
        public DateTime addedDate { set; get; }
        [Required]
        public int numbeInStock { set; get; }
    }
}