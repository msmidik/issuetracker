using System.ComponentModel.DataAnnotations;

namespace BL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        public string Email { set; get; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "user id " + Id;
        }
    }
}
