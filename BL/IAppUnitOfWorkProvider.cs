using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace BL
{
    public interface IAppUnitOfWorkProvider : IUnitOfWorkProvider
    {
        IAppUnitOfWork Create(DbContextOptions options);
        new IAppUnitOfWork Create();
        new IUnitOfWork GetCurrent();

    }
}