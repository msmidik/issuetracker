using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace DAL.Entities
{
    public class Notification : IEntity<int>
    {
        public int Id { set; get; }

        [Required]
        public virtual Issue Issue { set; get; }

        [Required]
        public int UserId { set; get; }

        public bool SendEmail { set; get; }

        public override string ToString()
        {
            return $"notification id {Id} on {Issue}";
        }


    }
}
