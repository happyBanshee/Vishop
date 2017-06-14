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

        [Display(Name = "Name")]
        public string name { set; get; }

        public Genres Genre { set; get; }

        [Display(Name = "Genre")]
      //  [Required]
        public int genresId { set; get; }

        //[Required]
        [Display(Name = "Release Date")]
        public DateTime releaseDate { set; get; }

     //   [Required]
        public DateTime addedDate { set; get; }

        //[Required]
        [Display(Name = "Number In Stock")]
        public int numbeInStock { set; get; }
    }
}