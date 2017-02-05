using Riganti.Utils.Infrastructure.Core;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;

namespace BL.Queries
{
    public class IssueListQuery : AppQuery<IssueDTO>
    {
        public IssueFilter Filter { get; set; }
        public IssueListQuery(IUnitOfWorkProvider provider) : base(provider)
        {
        }
        protected override IQueryable<IssueDTO> GetQueryable()
        {
            IQueryable<Issue> query = Context.Issues;

            if (Filter.ProjectId > 0)
            {
                query = Context.Issues.Where(s => s.Project.Id == Filter.ProjectId);
            }

            if (Filter.IssueType > 0)
            {
                query = Context.Issues.Where(s => s.Type.ToString().Equals( Filter.IssueType.ToString()) );
            }

            if (Filter.IssueState > 0)
            {
                query = Context.Issues.Where(s => s.State.ToString().Equals(Filter.IssueState.ToString()));
            }

            if (Filter.ProjectId > 0 && Filter.IssueType > 0)
            {
                query = Context.Issues.Where(s => s.Project.Id == Filter.ProjectId && s.Type.ToString().Equals(Filter.IssueType.ToString()) );
            }

            if (Filter.ProjectId > 0 && Filter.IssueState > 0)
            {
                query = Context.Issues.Where(s => s.Project.Id == Filter.ProjectId && s.State.ToString().Equals(Filter.IssueState.ToString()) );
            }

            return query.ProjectTo<IssueDTO>();
        }
    }
}