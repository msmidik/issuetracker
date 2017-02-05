using System.ComponentModel.DataAnnotations;

namespace BL.DTOs
{
    public class CommentDTO
    {
        public int Id { set; get; }

        [Required]
        public int AuthorId { set; get; }

        [Required]
        public string Text { set; get; }

        [Required]
        public IssueDTO Issue { set; get; }

        public override string ToString()
        {
            return $"comment id {Id}: {Text}";
        }

    }
}
