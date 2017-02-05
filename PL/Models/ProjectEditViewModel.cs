using System.Collections.Generic;
using BL.DTOs;
using System.Web.Mvc;

namespace PL.Models
{
    public class ProjectEditViewModel
    {
        public ProjectDTO Project { get; set; }

        public SelectList AvailableCustomers { get; set; }
        public int SelectedCustomerId { get; set; }

        public ProjectEditViewModel()
        {
            AvailableCustomers = new SelectList(new List<CustomerDTO>());
        }
    }
}