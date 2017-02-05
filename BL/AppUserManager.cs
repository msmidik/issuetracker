using DAL.Entities;
using Microsoft.AspNet.Identity;

namespace BL
{
    public class AppUserManager : UserManager<AppUser, int>
    {
        public AppUserManager(IUserStore<AppUser, int> store) : base(store)
        {
        }
    }
}