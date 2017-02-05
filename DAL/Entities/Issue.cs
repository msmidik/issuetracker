using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;
using DAL.Enums;

namespace DAL.Entities
{
    public class Issue : IEntity<int>
    {      
        public int Id { set; get; }

        [Required]
        public IssueType Type { set; get; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public IssueState State { set; get; }

        [MaxLength(30)]
        public string Informer { set; get; }

        public virtual Employee Solver { set; get; }

        [Required]
        public DateTime ApplicationDate { set; get; }

        public DateTime? FinishDate { set; get; }

        [Required]
        public virtual Project Project { set; get; }

        public virtual List<Comment> Comments { set; get; }

        public virtual List<Notification> Notifications { set; get; }

        public override string ToString()
        {
            return $"{Type} id {Id} on {Project}: {Name}";
        }
    }
}
