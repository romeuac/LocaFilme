using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocaFilme.Models;

namespace LocaFilme.ViewModels
{
    public class NewMovieViewModel
    {
        public Movie movie { get; set; }
        public IEnumerable<Genre> genres { get; set; }
    }
}