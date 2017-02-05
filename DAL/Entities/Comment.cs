using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace DAL.Entities
{
    public class Comment : IEntity<int>
    {
        public int Id { set; get; }

        [Required]
        public int AuthorId { set; get; }

        [Required, MaxLength(500)]
        public string Text { set; get; }

        [Required]
        public virtual Issue Issue { set; get; }

        public override string ToString()
        {
            return $"comment id {Id}: {Text}";
        }
    }
}
