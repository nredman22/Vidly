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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.ID == 0)   // new customer
                _context.Customers.Add(customer);
            else     // existing customer
            {
                var existingCustomer = _context.Customers.Single(c => c.ID == customer.ID);

                // manually change only the fields you want changed -- could use library automapper to update fields
                existingCustomer.Name = customer.Name;
                existingCustomer.Birthdate = customer.Birthdate;
                existingCustomer.MembershipTypeId = customer.MembershipTypeId;
                existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var foundCustomer = _context.Customers.SingleOrDefault(customer => customer.ID == id);

            if (foundCustomer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = foundCustomer
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Index()
        {
            // Utilizes eager loading to load the membership type
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var foundCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(customer => customer.ID == id);

            if (foundCustomer == null)
                return HttpNotFound();

            return View(foundCustomer);
        }
    }
}