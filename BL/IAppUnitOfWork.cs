using DAL;
using Riganti.Utils.Infrastructure.Core;

namespace BL
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        AppDbContext AppDbContext { get; }
    }
}