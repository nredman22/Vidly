using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class RentalOrderController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalOrderController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRentalOrder(RentalOrderDto rentalOrder)
        {

            if (rentalOrder.MovieIds.Count < 1)
            {
                return BadRequest("No Movies are specified");
            }

            // Will throw an exception if not found.
            var customer = _context.Customers.Single(c => c.ID == rentalOrder.CustomerId);

            var movies = _context.Movies.Where(m =>  rentalOrder.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalOrder.MovieIds.Count)
            {
                return BadRequest("Not all movies were found");
            }

            foreach (var movie in movies)
            {

                if (movie.NumberAvailable < 1)
                {
                    return BadRequest("Movie " + movie.Name + " is not available");
                }
                movie.NumberAvailable -= 1;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now.Date,
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}
