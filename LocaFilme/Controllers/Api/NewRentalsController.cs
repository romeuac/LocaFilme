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

            foreach(int movieId in newRental.MovieIds)
            {
                Rental rental = new Rental()
                {

                    DateRented = DateTime.Now,
                    Customer = _context.Customer.Single(c => c.Id == newRental.CustomerId),
                    Movie = _context.Movie.Single(m => m.Id == movieId)
                };

                rental.Movie.NumberAvailable--;

                _context.Rentals.Add(rental);

                _context.SaveChanges();

            }

            return Ok();
            //throw new NotImplementedException();
        }
    }
}
