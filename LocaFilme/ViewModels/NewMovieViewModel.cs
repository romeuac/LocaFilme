using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LocaFilme.Models;

namespace LocaFilme.ViewModels
{
    public class NewMovieViewModel
    {

        public IEnumerable<Genre> genres { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }

        public NewMovieViewModel()
        {
            Id = 0;
        }

        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }
    }
}