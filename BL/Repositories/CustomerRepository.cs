using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace BL.Repositories
{
    public class CustomerRepository : EntityFrameworkRepository<Customer, int>
    {
        public CustomerRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }
    }
}