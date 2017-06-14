using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vishop.Models;
using Vishop.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
            //var viewModel = new RandomMovieViewModel {
            //    Customer = getCustomers()
            //};

            return View(getCustomers());
        }


        [Route("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = getCustomers().SingleOrDefault(c => c.id == id);

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel { MembershipType = membershipTypes };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.id == 0)
            {
                // add it ti db context. In the memory, not in DB
                _context.Customers.Add(customer);
            } else
            {
                // Single returns exception if ID is not found in DB
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);
                //TryUpdateModel(customerInDb);
                // AutoMapper library to map all fields automaticaly

                customerInDb.name = customer.name;
                customerInDb.birthdate = customer.birthdate;
                customerInDb.membershipTypeId = customer.membershipTypeId;
                customerInDb.isSubscribedToNewsletter = customer.isSubscribedToNewsletter;
            }

            // based on modification sql request will be created to the run onto DB
            _context.SaveChanges();

            // redirect user to the list of customers
            return RedirectToAction("AllCustomers", "Customer");
        }
    }
}