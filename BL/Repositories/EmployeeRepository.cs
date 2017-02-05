using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace BL.Repositories
{
    public class EmployeeRepository : EntityFrameworkRepository<Employee, int>
    {
        public EmployeeRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }
    }
}