using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities
{
    public class AppUser : IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>
    {
    }
}