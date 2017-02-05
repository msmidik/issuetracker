using Riganti.Utils.Infrastructure.Core;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;

namespace BL.Queries
{
    public class ProjectListQuery : AppQuery<ProjectDTO>
    {
        public ProjectListQuery(IUnitOfWorkProvider provider) : base(provider)
        {

        }
        protected override IQueryable<ProjectDTO> GetQueryable()
        {
            IQueryable<Project> query = Context.Projects;

            return query.ProjectTo<ProjectDTO>();
        }
    }
}
