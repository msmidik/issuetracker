using BL.DTOs;
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
    public class NotificationController : Controller
    {
        private readonly NotificationFacade notificationFacade;
        private readonly IssueFacade issueFacade;

        public NotificationController(NotificationFacade notificationFacade, IssueFacade issueFacade)
        {
            this.notificationFacade = notificationFacade;
            this.issueFacade = issueFacade;
        }

        public ActionResult Index()
        {
            var issueViewModel = new NotificationViewModel()
            {
                Notifications = notificationFacade.GetAllNotifications()
            };
            return View(issueViewModel);
        }


        public ActionResult Create(int id)
        {
            var notificationEditViewModel = new NotificationEditViewModel()
            {
                Notification = new NotificationDTO(),
                SelectedIssueId = id

            };
            return View(notificationEditViewModel);
        }
        [HttpPost]
        public ActionResult Create(NotificationEditViewModel model)
        {
            var notification = model.Notification;
            notification.UserId = User.Identity.GetUserId<int>();
            notificationFacade.CreateNotification(notification, model.SelectedIssueId);
            return RedirectToAction("Details", "Issue", new { id = model.SelectedIssueId });
        }

        public ActionResult Edit(int id)
        {
            var notification = notificationFacade.GetNotificationsByIds(new int[] { id }).First();
            var notificationEditViewModel = new NotificationEditViewModel()
            {
                Notification = notification,
                SelectedIssueId = notification.Issue.Id
            };
            return View(notificationEditViewModel);
        }
        [HttpPost]
        public ActionResult Edit(NotificationEditViewModel model)
        {
            var notification = model.Notification;
            notification.UserId = User.Identity.GetUserId<int>();
            notificationFacade.UpdateNotification(notification, model.SelectedIssueId);
            return RedirectToAction("Index");
        }
/*
        public ActionResult Delete(int id)
        {
            notificationFacade.DeleteNotification(id);
            return RedirectToAction("Index");
        }
        */
    }
}
