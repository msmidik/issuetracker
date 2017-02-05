using DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace BL.Repositories
{
    public class NotificationRepository : EntityFrameworkRepository<Notification, int>
    {
        public NotificationRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }
    }
}