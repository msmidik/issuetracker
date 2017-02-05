using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BL
{
    public class AppRoleStore : RoleStore<AppRole, int, AppUserRole>
    {
        public AppRoleStore(IAppUnitOfWorkProvider unitOfWorkProvider)
           : base((unitOfWorkProvider.GetCurrent() as AppUnitOfWork)?.Context)
        {
        }
    }
}