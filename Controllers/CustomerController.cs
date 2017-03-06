using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

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

        //[Route("customer/add")]
        public ActionResult NewCustomer()
        {
            var membershipItems = _context.MembershipTypes.ToList();

            var newCustomerViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipItems
            };
            return View("CustomerForm", newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUpdateCustomer(CustomerFormViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = model.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return this.View("CustomerForm", viewModel);
            }
            if (model.Customer.Id == 0)
            {
                _context.Customers.Add(model.Customer);
            }
            else
            {
                var customer = _context.Customers.Single(c => c.Id == model.Customer.Id);

                customer.Name = model.Customer.Name;
                customer.BirthdayDate = model.Customer.BirthdayDate;
                customer.MembershipTypeId = model.Customer.MembershipTypeId;
                customer.IsSubscribedToNewsLetter = model.Customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return this.RedirectToAction("CustomersList", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return this.HttpNotFound();
            }

            var customerModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return this.View("CustomerForm", customerModel);
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