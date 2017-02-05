using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BL.DTOs
{
    public class ProjectDTO
    {
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        public CustomerDTO Customer { set; get; }

        public List<int> IssueStateNumbers { set; get; } = new List<int>();
        public List<int> IssueTypeNumbers { set; get; } = new List<int>();

        public override string ToString()
        {
            return Name;
        }
    }
}
