using Riganti.Utils.Infrastructure.Core;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;

namespace BL.Queries
{
    public class EmployeeListQuery : AppQuery<EmployeeDTO>
    {
        public EmployeeListQuery(IUnitOfWorkProvider provider) : base(provider)
        {

        }
        protected override IQueryable<EmployeeDTO> GetQueryable()
        {
            IQueryable<Employee> query = Context.Employees;

            return query.ProjectTo<EmployeeDTO>();
        }
    }
}
