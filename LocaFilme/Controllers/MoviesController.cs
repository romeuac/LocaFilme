﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LocaFilme.Migrations;
using System.Web;
using System.Web.Mvc;
using LocaFilme.Models;
using LocaFilme.ViewModels;

namespace LocaFilme.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

        }

        // Da maneira abaixo tem-se de passar 2 digitols para o month e de 1 a 12
        [Route("Movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("Movies/Index")]
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [Route("Movies/Details/{id:range(01,10)}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [Route("Movies/New")]
        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel
            {
                genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        //[Route("Movies/Update/")]
        public ActionResult Update(int id)
        {
            Movie Movie = _context.Movie.Single(m => m.Id == id);

            if (Movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel(Movie)
            {
                genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            // Checando se os parametros passados sao validos
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            // Se trata de um novo movie
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movie.Add(movie);
            }

            else
            {
                var movieInDB = _context.Movie.Single(m => m.Id == movie.Id);

                movieInDB.Name = movie.Name;
                movieInDB.Genre = movie.Genre;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberInStock = movie.NumberInStock;
                
                movieInDB.ReleaseDate = movie.ReleaseDate;
            }

            // Para persistir as mudanças no DB
            _context.SaveChanges();

            // Volta para a pagina de Index
            return RedirectToAction("index", "Movies");
        }
    }
}