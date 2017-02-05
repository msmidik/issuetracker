using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace BL.Repositories
{
    public class IssueRepository : EntityFrameworkRepository<Issue, int>
    {
        public IssueRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }
    }
}