using System.ComponentModel.DataAnnotations;

namespace BL.DTOs
{
    public class NotificationDTO
    {
        public int Id { set; get; }

        [Required]
        public IssueDTO Issue { set; get; }

        [Required]
        public int UserId { set; get; }

        public bool SendEmail { set; get; }

        public override string ToString()
        {
            return $"notification id {Id} on {Issue}";
        }

    }
}
