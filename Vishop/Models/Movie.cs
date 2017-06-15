using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vishop.Models
{
    public class Movie
    {
        public int Id { set; get; }
        [Display(Name = "Name")]
        [Required]
        [StringLength(255)]
        public string Name { set; get; }

        public Genres Genre { set; get; }

        [Display(Name = "Genre")]
        [Required]
        public int GenresId { set; get; }

        //[Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { set; get; }

     //   [Required]
        public DateTime AddedDate { set; get; }

        //[Required]
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public int NumberInStock { set; get; }
    }
}