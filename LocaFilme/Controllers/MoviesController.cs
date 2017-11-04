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
            var movies = _context.Movie.Include(m => m.Genre).ToList();
            return View(movies);
        }

        [Route("Movies/Details/{id:range(01,10)}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        [Route("Movies/New")]
        public ActionResult New()
        {
            var viewModel = new NewMovieViewModel
            {
                //movie = new Movie(),
                genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            movie.DateAdded = DateTime.Now;
            _context.Movie.Add(movie);

            // Para persistir as mudanças no DB
            _context.SaveChanges();

            // Volta para a pagina de Index
            return RedirectToAction("index", "Movies");
        }

        [Route("Movies/Update")]
        public ActionResult Update(int id)
        {
            var viewModel = new NewMovieViewModel
            {
                movie = _context.Movie.Single(m => m.Id == id),
                genres = _context.Genres.ToList()
            };
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            var movieInDB = _context.Movie.Single(m => m.Id == movie.Id);

            movieInDB.Name = movie.Name;
            movieInDB.Genre = movie.Genre;
            movieInDB.GenreId = movie.GenreId;
            movieInDB.NumberInStock = movie.NumberInStock;
            movieInDB.ReleaseDate = movie.ReleaseDate;

            // Para persistir as mudanças no DB
            _context.SaveChanges();

            // Volta para a pagina de Index
            return RedirectToAction("index", "Movies");
        }
    }
}