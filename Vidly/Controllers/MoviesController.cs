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
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

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

        public ActionResult Details(int id)
        {
            var movies = GetMovies();

            var foundMovie = movies.SingleOrDefault(movie => movie.ID == id);

            if (foundMovie == null)
                return HttpNotFound();

            return View(foundMovie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie() { ID = 1, Name = "Bad Boys" },
                new Movie() { ID = 2, Name = "Die Hard" }
            };

        }
    }
}