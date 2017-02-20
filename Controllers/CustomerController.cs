using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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


        // GET: Customer
        [Route("customer/list")]
        public ActionResult CustomersList()
        {
            var customerList = this._context.Customers.Include(c => c.MembershipType).ToList();
            return View(customerList);
        }

        [Route("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = this._context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            
            if (customer == null)
            {
                return this.HttpNotFound();
            }

            return View(customer);
        }

       // private IEnumerable<Customer> GetCustomers()
       // {
       //     return new List<Customer>
       //     {
       //         new Customer { Id = 1, Name = "Shruti" },
       //         new Customer { Id = 2, Name = "Archana" }
       //     };
       //}
    }
}