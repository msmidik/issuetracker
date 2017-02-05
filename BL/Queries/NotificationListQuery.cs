using Riganti.Utils.Infrastructure.Core;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BL.DTOs;
using DAL.Entities;

namespace BL.Queries
{
    public class NotificationListQuery : AppQuery<NotificationDTO>
    {
        public NotificationFilter Filter { get; set; }
        public NotificationListQuery(IUnitOfWorkProvider provider) : base(provider)
        {

        }
        protected override IQueryable<NotificationDTO> GetQueryable()
        {
            IQueryable<Notification> query = Context.Notifications;

            if (Filter.IssueId > 0)
            {
                query = Context.Notifications.Where(s => s.Issue.Id == Filter.IssueId);
            }

            if (Filter.UserId > 0)
            {
                query = Context.Notifications.Where(s => s.UserId == Filter.UserId);
            }

            if (Filter.UserId > 0 && Filter.IssueId > 0)
            {
                query = Context.Notifications.Where(s => s.UserId == Filter.UserId && s.Issue.Id == Filter.IssueId);
            }

            return query.ProjectTo<NotificationDTO>();
        }
    }
}
