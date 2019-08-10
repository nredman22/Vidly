using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customers = new List<Customer>
            {
                new Customer() { ID = 1, Name = "Tom Brady" },
                new Customer() { ID = 2, Name = "Kirk Cousins" }
            };

            var foundCustomer = new Customer();
            try
            {
                foundCustomer = customers.First(movie => movie.ID == id);
            }
            catch
            {
                return HttpNotFound();

            }

            return View(foundCustomer);
        }
    }
}