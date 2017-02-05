using Riganti.Utils.Infrastructure.Core;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;

namespace BL.Queries
{
    public class CustomerListQuery : AppQuery<CustomerDTO>
    {
        public CustomerListQuery(IUnitOfWorkProvider provider) : base(provider)
        {

        }
        protected override IQueryable<CustomerDTO> GetQueryable()
        {
            IQueryable<Customer> query = Context.Customers;

            return query.ProjectTo<CustomerDTO>();
        }
    }
}
