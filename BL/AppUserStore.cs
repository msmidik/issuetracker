using DAL;
using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BL
{
    public class AppUserStore : UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public AppUserStore(IAppUnitOfWorkProvider unitOfWorkProvider)
           : base((unitOfWorkProvider.GetCurrent() as AppUnitOfWork)?.Context)
        {
        }

        public AppUserStore(AppDbContext context)
           : base(context)
        {
        }

    }
}