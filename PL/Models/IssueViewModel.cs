using BL.DTOs;
using BL.Enums;
using System.Collections.Generic;

namespace PL.Models
{
    public class IssueViewModel
    {
        public List<IssueDTO> Issues { get; set; }
        public List<ProjectDTO> Projects { get; set; }
        public List<IssueType> IssueTypes { get; set; }
        public List<IssueState> IssueStates { get; set; }


        public IssueViewModel()
        {
            Issues = new List<IssueDTO>();
            Projects = new List<ProjectDTO>();
            IssueTypes = new List<IssueType>();
            IssueStates = new List<IssueState>();
        }
    }
}