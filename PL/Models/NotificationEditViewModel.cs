using System.Collections.Generic;
using BL.DTOs;
using System.Web.Mvc;

namespace PL.Models
{
    public class NotificationEditViewModel
    {
        public NotificationDTO Notification { get; set; }
        public int SelectedIssueId { get; set; }

    }
}