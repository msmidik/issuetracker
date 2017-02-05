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
    public class EmployeeController : Controller
    {
        private readonly EmployeeFacade employeeFacade;

        public EmployeeController(EmployeeFacade employeeFacade)
        {
            this.employeeFacade = employeeFacade;
        }

        public ActionResult Index()
        {
            var issueViewModel = new EmployeeViewModel()
            {
                Employees = employeeFacade.GetAllEmployees()
            };
            return View(issueViewModel);
        }


        public ActionResult Create()
        {
            var employeeEditViewModel = new EmployeeEditViewModel()
            {
                Employee = new EmployeeDTO(),

            };
            return View(employeeEditViewModel);
        }
        [HttpPost]
        public ActionResult Create(EmployeeEditViewModel model)
        {
            employeeFacade.CreateEmployee(model.Employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var employee = employeeFacade.GetEmployeesByIds(new int[] { id }).First();
            var employeeEditViewModel = new EmployeeEditViewModel()
            {
                Employee = employee
            };
            return View(employeeEditViewModel);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeEditViewModel model)
        {
            employeeFacade.UpdateEmployee(model.Employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            employeeFacade.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}
