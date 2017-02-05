using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities
{
    public class AppRole : IdentityRole<int, AppUserRole>
    {
    }
}