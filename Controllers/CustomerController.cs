using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly List<Customer> _customersList = new List<Customer> { new Customer { Id = 1, Name = "Shruti" }, new Customer { Id = 2, Name = "Archana" } };

        // GET: Customer
        [Route("customer/list")]
        public ActionResult CustomersList()
        {
            var customerList = this.GetCustomers();
            return View(customerList);
        }

        [Route("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            var customerList = this.GetCustomers();
            var customer = customerList.FirstOrDefault(d => d.Id == id);

            if (customer == null)
            {
                return this.HttpNotFound();
            }

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Shruti" },
                new Customer { Id = 2, Name = "Archana" }
            };
       }
    }
}