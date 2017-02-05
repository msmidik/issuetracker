using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace DAL.Entities
{
    public class Project : IEntity<int>
    {
        public int Id { set; get; }

        [Required, MaxLength(50)]
        public string Name { set; get; }

        // required annotation will cause sqlException - cascade delete
        public virtual Customer Customer { set; get; }

        public virtual List<Issue> Issues { set; get; }

        public override string ToString()
        {
            return Name;
        }


    }
}
