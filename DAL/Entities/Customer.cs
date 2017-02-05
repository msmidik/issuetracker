using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace DAL.Entities
{
    public class Customer : User , IEntity<int>
    {
        [Required, MaxLength(30)]
        public string Name { set; get; }

        public virtual List<Project> Projects { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
