using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace DAL.Entities
{
    public class Employee : User , IEntity<int>
    {
        [Required, MaxLength(30)]
        public string FirstName { set; get; }

        [Required, MaxLength(30)]
        public string Surname { set; get; }

        public virtual List<Issue> SolvedIssues { set; get; }

        public override string ToString()
        {
            return FirstName + " " + Surname;
        }

    }
}