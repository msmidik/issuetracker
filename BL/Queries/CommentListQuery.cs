using Riganti.Utils.Infrastructure.Core;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;

namespace BL.Queries
{
    public class CommentListQuery : AppQuery<CommentDTO>
    {
        public CommentFilter Filter { get; set; }
        public CommentListQuery(IUnitOfWorkProvider provider) : base(provider)
        {

        }
        protected override IQueryable<CommentDTO> GetQueryable()
        {
            IQueryable<Comment> query = Context.Comments;
            if (Filter.IssueId > 0)
            {
                query = Context.Comments.Where(s => s.Issue.Id == Filter.IssueId);
            }

            return query.ProjectTo<CommentDTO>();
        }
    }
}
