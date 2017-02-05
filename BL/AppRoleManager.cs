using DAL.Entities;
using Microsoft.AspNet.Identity;

namespace BL
{
    public class AppRoleManager : RoleManager<AppRole, int>
    {
        public AppRoleManager(IRoleStore<AppRole, int> store) : base(store)
        {
        }
    }
}