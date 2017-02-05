using AutoMapper;
using BL.Queries;
using BL.Repositories;
using Riganti.Utils.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using BL.DTOs;
using DAL.Entities;

namespace BL.Facades
{
    public class CustomerFacade : AppFacadeBase
    {
        public CustomerRepository Repository { get; set; }

        public CustomerListQuery CustomerListQuery { get; set; }


        protected IQuery<CustomerDTO> CreateQuery()
        {
            var query = CustomerListQuery;
            return query;
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery().Execute().ToList();
            }
        }

        public List<CustomerDTO> GetCustomersByIds(int[] ids)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appCustomers = Repository.GetByIds(ids);
                return Mapper.Map<List<CustomerDTO>>(appCustomers);
            }
        }

        public void CreateCustomer(CustomerDTO customer)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalCustomer = Mapper.Map<Customer>(customer);
                Repository.Insert(dalCustomer);
                uow.Commit();
            }
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appCustomer = Repository.GetById(customer.Id);
                Mapper.Map(customer, appCustomer);
                Repository.Update(appCustomer);
                uow.Commit();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                Repository.Delete(customerId);
                uow.Commit();
            }
        }


    }
}
