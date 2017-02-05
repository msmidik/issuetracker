using BL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BL.DTOs
{
    public class IssueDTO
    {
        public int Id { set; get; }

        [Required]
        public IssueType Type { set; get; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public IssueState State { set; get; }

        public string Informer { set; get; }

        public EmployeeDTO Solver { set; get; }

        [Required]
        public DateTime ApplicationDate { set; get; }

        public DateTime? FinishDate { set; get; }

        [Required]
        public ProjectDTO Project { set; get; }

        public override string ToString()
        {
            return $"{Type} id {Id} on {Project}: {Name}";
        }

    }
}
