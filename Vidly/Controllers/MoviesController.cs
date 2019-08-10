using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            //// how our movie actually gets passed
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model = movie

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // Attribute routing uses attribute route constraints
        [Route("movies/released/{year}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var movies = new List<Movie>
            {
                new Movie() { ID = 1, Name = "Bad Boys" },
                new Movie() { ID = 2, Name = "Die Hard" }
            };

            var foundMovie = new Movie();
            try
            {
                foundMovie = movies.First(movie => movie.ID == id);
            }
            catch
            {
                return HttpNotFound();

            }

            return View(foundMovie);
        }
    }
}