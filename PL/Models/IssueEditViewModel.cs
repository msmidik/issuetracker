using System.Collections.Generic;
using BL.DTOs;
using System.Web.Mvc;
using BL.Enums;
using System;

namespace PL.Models
{
    public class IssueEditViewModel
    {
        public IssueDTO Issue { get; set; }

        public SelectList AvailableProjects { get; set; }
        public int SelectedProjectId { get; set; }
        public SelectList AvailableTypes { get; set; }
        public SelectList AvailableStates { get; set; }

        public SelectList AvailableEmployees { get; set; }
        public int SelectedEmployeeId { get; set; }
        public List<Tuple<CommentDTO, string>> CommentsAndNames { get; set; }
        public CommentDTO NewComment { get; set; }
        public bool HasNotification { get; set; }


        public IssueEditViewModel()
        {
            AvailableProjects = new SelectList(new List<ProjectDTO>());
            AvailableEmployees = new SelectList(new List<EmployeeDTO>());
            AvailableTypes = new SelectList(new List<IssueType>());
            AvailableStates = new SelectList(new List<IssueState>());
            CommentsAndNames = new List<Tuple<CommentDTO, string>>();
        }
    }
}