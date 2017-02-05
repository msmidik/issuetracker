using System.ComponentModel.DataAnnotations;

namespace BL.DTOs
{
    public class EmployeeDTO : UserDTO
    {
        [Required]
        public string FirstName { set; get; }

        [Required]
        public string Surname { set; get; }

        public override string ToString()
        {
            return FirstName + " " + Surname;
        }
    }
}
