using LocaFilme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using LocaFilme.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace LocaFilme.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext _context{ get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies/
        public  IHttpActionResult GetMovie(string query = null)
        {
            var moviesQuery = _context.Movie
                .Include(m => m.Genre);

            // Pegando apenas aquelas que tem a query satisfeita
            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query) && m.NumberAvailable > 0);

                //moviesQuery = moviesQuery.Where(m => m.NumberAvailable > 0);
            }

            var movieDto = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDto);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }

        // POST /api/movies/
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            // Criei a prop NumberAviable no Dto tb
            //movie.NumberAvailable = movieDto.NumberInStock;

            _context.Movie.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            movieDto.DateAdded = movie.DateAdded;

            return Created(new Uri(Request.RequestUri + movieDto.Id.ToString()), movieDto);
            
        }

        // PUT /api/movies/
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            var movieInDb = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

        }

        // DELETE /api/movies/
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
