using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
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

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Title = "New Movie",
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Title = "Edit Movie",
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var foundMovie = _context.Movies.Single(m => m.Id == movie.Id);
                foundMovie.Name = movie.Name;
                foundMovie.ReleaseDate = movie.ReleaseDate;
                foundMovie.InStock = movie.InStock;
                foundMovie.GenreId = movie.GenreId;
            }

            _context.SaveChanges();


            return RedirectToAction("Index");
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

            var foundMovie = _context.Movies.Include(m => m.Genre).SingleOrDefault(movie => movie.Id == id);

            if (foundMovie == null)
                return HttpNotFound();

            return View(foundMovie);
        }
    }
}