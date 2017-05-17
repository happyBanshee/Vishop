using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vishop.Models;
using Vishop.ViewModels;

namespace Vishop.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> mockCustomers() {
            List<Customer> customersList = new List<Customer> {
                new Customer { name ="Mark Twain",id=0},
                new Customer { name ="Steven King",id=1}
            };

            return customersList;
        }
        
        // GET: Customer
        public ActionResult AllCustomers()
        {
            var viewModel = new RandomMovieViewModel {
                Customer = mockCustomers()
            };

            return View(viewModel);
        }
    [Route("customer/details/{id}")]
    public ActionResult Details(int id)
    {
            List<Customer> list = mockCustomers();
     
            return View(list.ElementAt(id));
        }
    }
}