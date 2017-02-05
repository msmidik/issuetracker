using System.Collections.Generic;
using Riganti.Utils.Infrastructure.Core;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Email { set; get; }

        public virtual List<Comment> Comments { set; get; }

        public virtual List<Notification> Notifications { set; get; }

        public override string ToString()
        {
            return "user id " + Id;
        }
    }
}
