using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Movies()
        {
            var movies = new List<Movie>
            {
                new Movie() { ID = 1, Name = "Bad Boys" },
                new Movie() { ID = 2, Name = "Die Hard" }
            };

            var viewModel = new MoviesViewModel() { Movies = movies };

            return View(viewModel);
        }

        public ActionResult Customers()
        {
            var customers = new List<Customer>
            {
                new Customer() { ID = 1, Name = "Tom Brady" },
                new Customer() { ID = 2, Name = "Kirk Cousins" }
            };

            var viewModel = new CustomerViewModel()
            {
                Customers = customers
            };

            return View(viewModel);
        }
    }
}