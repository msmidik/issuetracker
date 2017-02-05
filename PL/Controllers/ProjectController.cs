using BL.DTOs;
using BL.Enums;
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
    public class ProjectController : Controller
    {
        private readonly CustomerFacade customerFacade;
        private readonly ProjectFacade projectFacade;
        private readonly IssueFacade issueFacade;

        public ProjectController(CustomerFacade customerFacade, ProjectFacade projectFacade, IssueFacade issueFacade)
        {
            this.projectFacade = projectFacade;
            this.customerFacade = customerFacade;
            this.issueFacade = issueFacade;
        }

        public ActionResult Index()
        {
            var issueTypes = new List<IssueType>();
            var issueStates = new List<IssueState>();

            foreach (IssueType t in Enum.GetValues(typeof(IssueType)))
            {
                issueTypes.Add(t);
            }
 
            foreach (IssueState s in Enum.GetValues(typeof(IssueState)))
            {
                issueStates.Add(s);
            }

            var projects = projectFacade.GetAllProjects();
            foreach (ProjectDTO p in projects)
            {
                foreach (IssueType t in issueTypes)
                {
                    p.IssueTypeNumbers
                        .Add(issueFacade.GetIssueByProjectAndType(p.Id, t).Count);
                }

                foreach (IssueState s in issueStates)
                {
                    p.IssueStateNumbers
                        .Add(issueFacade.GetIssueByProjectAndState(p.Id, s).Count);
                }

            }


            var projectViewModel = new ProjectViewModel()
            {
                Customers = customerFacade.GetAllCustomers(),
                Projects = projects,  
                IssueStates = issueStates,
                IssueTypes = issueTypes
            };
            return View(projectViewModel);
        }

        public ActionResult Create()
        {
            var projectEditViewModel = new ProjectEditViewModel()
            {
                Project = new ProjectDTO(),

                AvailableCustomers = new SelectList(customerFacade.GetAllCustomers(), "Id", "Name")
            };
            return View(projectEditViewModel);
        }
        [HttpPost]
        public ActionResult Create(ProjectEditViewModel model)
        {
            projectFacade.CreateProject(model.Project, model.SelectedCustomerId);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var project = projectFacade.GetProjectsByIds(new int[] { id }).First();
            var projectEditViewModel = new ProjectEditViewModel()
            {
                Project = project,
                SelectedCustomerId = project.Customer.Id,
                AvailableCustomers = new SelectList(customerFacade.GetAllCustomers(), "Id", "Name")
            };
            return View(projectEditViewModel);
        }
        [HttpPost]
        public ActionResult Edit(ProjectEditViewModel model)
        {
            projectFacade.UpdateProject(model.Project, model.SelectedCustomerId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            projectFacade.DeleteProject(id);
            return RedirectToAction("Index");
        }


    }
}
