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
            var customers = GetCustomers();

            return View(customers);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customers = GetCustomers();

            var foundCustomer = customers.SingleOrDefault(customer => customer.ID == id);

            if (foundCustomer == null)
                return HttpNotFound();

            return View(foundCustomer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer() { ID = 1, Name = "Tom Brady" },
                new Customer() { ID = 2, Name = "Kirk Cousins" }
            };
        }
    }
}