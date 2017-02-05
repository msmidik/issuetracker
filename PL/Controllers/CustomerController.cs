using BL.DTOs;
using BL.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL.Models;

namespace PL.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly CustomerFacade customerFacade;

        public CustomerController(CustomerFacade customerFacade)
        {
            this.customerFacade = customerFacade;
        }

        public ActionResult Index()
        {
            var issueViewModel = new CustomerViewModel()
            {
                Customers = customerFacade.GetAllCustomers()    
            };
            return View(issueViewModel);
        }


        public ActionResult Create()
        {
            var customerEditViewModel = new CustomerEditViewModel()
            {
                Customer = new CustomerDTO(),

            };
            return View(customerEditViewModel);
        }
        [HttpPost]
        public ActionResult Create(CustomerEditViewModel model)
        {
            customerFacade.CreateCustomer(model.Customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = customerFacade.GetCustomersByIds(new int[] { id }).First();
            var customerEditViewModel = new CustomerEditViewModel()
            {
                Customer = customer
            };
            return View(customerEditViewModel);
        }
        [HttpPost]
        public ActionResult Edit(CustomerEditViewModel model)
        {
            customerFacade.UpdateCustomer(model.Customer);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            customerFacade.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

    }
}
