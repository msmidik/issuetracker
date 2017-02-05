using BL.Enums;

namespace BL.DTOs
{
    public class IssueFilter
    {
        public int ProjectId { get; set; }
        public IssueType IssueType { get; set; }
        public IssueState IssueState { get; set; }
    }
}
