using BL.DTOs;
using BL.Enums;
using BL.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL.Models;
using Microsoft.AspNet.Identity;

namespace PL.Controllers
{
    [Authorize]
    public class IssueController : Controller
    {
        private readonly IssueFacade issueFacade;
        private readonly ProjectFacade projectFacade;
        private readonly EmployeeFacade employeeFacade;
        private readonly CommentFacade commentFacade;
        private readonly UserFacade userFacade;
        private readonly NotificationFacade notificationFacade;
        private readonly List<IssueType> issueTypes;
        private readonly List<IssueState> issueStates;

        public IssueController(IssueFacade issueFacade, ProjectFacade projectFacade, EmployeeFacade employeeFacade, CommentFacade commentFacade, UserFacade userFacade, NotificationFacade notificationFacade)
        {
            this.projectFacade = projectFacade;
            this.issueFacade = issueFacade;
            this.employeeFacade = employeeFacade;
            this.commentFacade = commentFacade;
            this.userFacade = userFacade;
            this.notificationFacade = notificationFacade;

            issueTypes = new List<IssueType>();
            issueStates = new List<IssueState>();

            foreach (IssueType t in Enum.GetValues(typeof(IssueType)))
            {
                issueTypes.Add(t);
            }

            foreach (IssueState s in Enum.GetValues(typeof(IssueState)))
            {
                issueStates.Add(s);
            }

        }

        public ActionResult Index()
        {

            var issueViewModel = new IssueViewModel()
            {
                Issues = issueFacade.GetAllIssues(),
                Projects = projectFacade.GetAllProjects(),
                IssueStates = issueStates,
                IssueTypes = issueTypes
            };

            return View(issueViewModel);
        }



        public ActionResult Create()
        {
            var issueEditViewModel = new IssueEditViewModel()
            {
                Issue = new IssueDTO(),

                AvailableProjects = new SelectList(projectFacade.GetAllProjects(), "Id", "Name"),
                AvailableTypes = new SelectList(Enum.GetValues(typeof(IssueType)).Cast<IssueType>()),
                AvailableStates = new SelectList(Enum.GetValues(typeof(IssueState)).Cast<IssueState>())
            };
            return View(issueEditViewModel);
           
        }
        [HttpPost]
        public ActionResult Create(IssueEditViewModel model)
        {
            model.Issue.ApplicationDate = DateTime.Now;
            model.Issue.State = IssueState.New;
            issueFacade.CreateIssue(model.Issue, model.SelectedProjectId);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var issue = issueFacade.GetIssuesByIds(new int[] { id }).First();
            int selectedEmployeeId = -1;
            if (issue.Solver != null)
            {
                selectedEmployeeId = issue.Solver.Id;
            }

                var issueEditViewModel = new IssueEditViewModel()
            {  
                Issue = issue,
                SelectedProjectId = issue.Project.Id,
                AvailableProjects = new SelectList(projectFacade.GetAllProjects(), "Id", "Name"),
                SelectedEmployeeId = selectedEmployeeId,
                AvailableEmployees = new SelectList(employeeFacade.GetAllEmployees(), "Id", "Surname"),
                AvailableTypes = new SelectList(Enum.GetValues(typeof(IssueType)).Cast<IssueType>().ToList()),
                AvailableStates = new SelectList(Enum.GetValues(typeof(IssueState)).Cast<IssueState>().ToList()),
            };

            return View(issueEditViewModel);
        }
        [HttpPost]
        public ActionResult Edit(IssueEditViewModel model)
        {
            issueFacade.UpdateIssue(model.Issue, model.SelectedProjectId, model.SelectedEmployeeId);

            var hasNotification = notificationFacade.ExistsForIssueAndUser(model.Issue.Id, User.Identity.GetUserId<int>());
            if (hasNotification)
            {
                issueFacade.SendEmail(model.Issue.Name + " edited");
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var issue = issueFacade.GetIssuesByIds(new int[] { id }).First();

            var comments = commentFacade.GetCommentByIssue(id);
            var commentsAndNames = new List<Tuple<CommentDTO, string>>();
            foreach (CommentDTO c in comments)
            {
                var author = userFacade.GetUserById(id).UserName;
                commentsAndNames.Add(new Tuple<CommentDTO, string>(c, author));
            }

            var issueEditViewModel = new IssueEditViewModel()
            {
                Issue = issue,
                SelectedProjectId = issue.Project.Id,
                AvailableProjects = new SelectList(projectFacade.GetAllProjects(), "Id", "Name"),
                AvailableEmployees = new SelectList(employeeFacade.GetAllEmployees(), "Id", "Surname"),
                AvailableTypes = new SelectList(Enum.GetValues(typeof(IssueType)).Cast<IssueType>().ToList()),
                AvailableStates = new SelectList(Enum.GetValues(typeof(IssueState)).Cast<IssueState>().ToList()),
                CommentsAndNames = commentsAndNames,
                HasNotification = notificationFacade.ExistsForIssueAndUser(id, User.Identity.GetUserId<int>())
            };

            return View(issueEditViewModel);
        }

        [HttpPost]
        public ActionResult Details(IssueEditViewModel model)
        {
            CommentDTO comment = model.NewComment;
            comment.AuthorId = User.Identity.GetUserId<int>();
            int issueId = model.Issue.Id;
            commentFacade.CreateComment(comment, issueId);
            return RedirectToAction("Details");
        }

        public ActionResult IssuesByType(IssueType type)
        {
            var issueViewModel = new IssueViewModel()
            {
                Issues = issueFacade.GetIssueByType(type),
                Projects = projectFacade.GetAllProjects(),
                IssueTypes = issueTypes,
                IssueStates = issueStates
            };
            return View("Index", issueViewModel);
        }

        public ActionResult IssuesByState(IssueState state)
        {
            var issueViewModel = new IssueViewModel()
            {
                Issues = issueFacade.GetIssueByState(state),
                Projects = projectFacade.GetAllProjects(),
                IssueTypes = issueTypes,
                IssueStates = issueStates
            };
            return View("Index", issueViewModel);
        }

        public ActionResult IssueByProject(int projectId)
        {
            var issueViewModel = new IssueViewModel()
            {
                Issues = issueFacade.GetIssueByProject(projectId),
                Projects = projectFacade.GetAllProjects(),
                IssueTypes = issueTypes,
                IssueStates = issueStates
                
            };
            return View("Index", issueViewModel);
        }


        /*
        public ActionResult Delete(int id)
        {
            issueFacade.DeleteIssue(id);
            return RedirectToAction("Index");
        }
        */

    }
}