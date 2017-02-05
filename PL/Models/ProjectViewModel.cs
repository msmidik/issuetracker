using BL.DTOs;
using BL.Enums;
using System.Collections.Generic;

namespace PL.Models
{
    public class ProjectViewModel
    {
        public List<CustomerDTO> Customers { get; set; }
        public List<ProjectDTO> Projects { get; set; }
        public List<IssueType> IssueTypes { get; set; }
        public List<IssueState> IssueStates { get; set; }

        public ProjectViewModel()
        {
            Customers = new List<CustomerDTO>();
            Projects = new List<ProjectDTO>();
            IssueTypes = new List<IssueType>();
            IssueStates = new List<IssueState>();
            
        }
    }
}