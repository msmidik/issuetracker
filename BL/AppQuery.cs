using DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace BL
{
    public abstract class AppQuery<T> : EntityFrameworkQuery<T>
    {
        public new AppDbContext Context => (AppDbContext)base.Context;

        public AppQuery(IUnitOfWorkProvider provider) : base(provider)
        {

        }
    }
}
