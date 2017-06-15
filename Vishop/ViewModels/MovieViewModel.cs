using System;
using System.Collections.Generic;
using Vishop.Models;
using System.ComponentModel.DataAnnotations;


namespace Vishop.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genres> Genre { set; get; }
        public int? Id { set; get; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(255)]
        public string Name { set; get; }
        
        [Display(Name = "Genre")]
        [Required]
        public int? GenresId { set; get; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { set; get; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int? NumberInStock { set; get; }


        public MovieViewModel() {
            Id = 0;
        }
        public MovieViewModel(Movie mov) {
            Id = mov.Id;
            Name = mov.Name;
            GenresId = mov.GenresId;
            ReleaseDate = mov.ReleaseDate;
            NumberInStock = mov.NumberInStock;
        }

        public string Title
        {
            get
            {
                return Id != null && Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}