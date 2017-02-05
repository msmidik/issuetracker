using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace BL.Repositories
{
    public class ProjectRepository : EntityFrameworkRepository<Project, int>
    {
        public ProjectRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }
    }
}
