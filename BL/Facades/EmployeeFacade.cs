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
    public class EmployeeFacade : AppFacadeBase
    {
        public EmployeeRepository Repository { get; set; }

        public EmployeeListQuery EmployeeListQuery { get; set; }


        protected IQuery<EmployeeDTO> CreateQuery()
        {
            var query = EmployeeListQuery;
            return query;
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery().Execute().ToList();
            }
        }

        public List<EmployeeDTO> GetEmployeesByIds(int[] ids)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appEmployees = Repository.GetByIds(ids);
                return Mapper.Map<List<EmployeeDTO>>(appEmployees);
            }
        }

        public void CreateEmployee(EmployeeDTO employee)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalEmployee = Mapper.Map<Employee>(employee);
                Repository.Insert(dalEmployee);
                uow.Commit();
            }
        }

        public void UpdateEmployee(EmployeeDTO employee)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appEmployee = Repository.GetById(employee.Id);
                Mapper.Map(employee, appEmployee);
                Repository.Update(appEmployee);
                uow.Commit();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                Repository.Delete(employeeId);
                uow.Commit();
            }
        }

    }
}
