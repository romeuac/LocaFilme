using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LocaFilme.Dtos
{
    public class MovieDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int GenreId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public MovieDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}