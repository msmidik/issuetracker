using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public string Code { get; set; }
    }
}