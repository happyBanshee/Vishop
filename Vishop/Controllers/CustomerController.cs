using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vishop.Models;
using Vishop.ViewModels;
using System.Data.Entity;

namespace Vishop.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private List<Customer> getCustomers()
        {

         var customersList = _context.Customers.Include(c => c.membershipType).ToList();
         

            return customersList;
        }

        // GET: Customer
        public ActionResult AllCustomers()
        {
            var viewModel = new RandomMovieViewModel {
                Customer = getCustomers()
            };

            return View(viewModel);
        }
        [Route("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = getCustomers().SingleOrDefault(c => c.id == id);

            return View(customer);
        }
    }
}