using BL.DTOs;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PL.Models
{
    public class NotificationViewModel
    {
        public List<NotificationDTO> Notifications { get; set; }
       
        public NotificationViewModel()
        {
            Notifications = new List<NotificationDTO>();
        }
    }
}