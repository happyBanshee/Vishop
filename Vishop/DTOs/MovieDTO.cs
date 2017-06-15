using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vishop.DTOs
{
    public class MovieDTO
    {
        public int Id { set; get; }
        [Required]
        [StringLength(255)]
        public string Name { set; get; }

        [Required]
        public int GenresId { set; get; }

        public DateTime ReleaseDate { set; get; }

        public DateTime AddedDate { set; get; }

        [Range(1, 20)]
        public int NumberInStock { set; get; }
    }
}