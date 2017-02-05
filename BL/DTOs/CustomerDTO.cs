using System.ComponentModel.DataAnnotations;

namespace BL.DTOs
{
    public class CustomerDTO : UserDTO
    {
        [Required]
        public string Name { set; get; }

        public override string ToString()
        {
            return Name;
        }

    }
}
