using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LocaFilme.Dtos;
using LocaFilme.Models;

namespace LocaFilme.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        public ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // If no movies IDs have been given
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movies Ids have been given.");

            var customer = _context.Customer.SingleOrDefault(c => c.Id == newRental.CustomerId);

            // In case of invalid customer
            if (customer == null)
                return BadRequest("CustomerId is invalid.");

            var movies = _context.Movie.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            // Verificando se tem algum MovieId invalido
            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more moviesIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not Available.");

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    DateRented = DateTime.Now,
                    Customer = customer,
                    Movie = movie
                };


                _context.Rentals.Add(rental);

                _context.SaveChanges();

            }

            return Ok();
            //throw new NotImplementedException();
        }
    }
}
