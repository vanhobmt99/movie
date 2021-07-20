using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Please Enter Name of Movie")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Year")]
        [Range(1900, 2099, ErrorMessage = "Must be invailid Year")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please enter rating ")]
        [Range(1, 5, ErrorMessage = "Rating must be 1 to 5")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Please Enter a genre.")]
        public string GenreID { get; set; }
        public Genre Genre { get; set; }
    }

    public class Genre
    {
        public string GenreID { get; set; }
        public string Name { get; set; }
    }
}
