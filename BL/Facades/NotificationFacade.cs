using AutoMapper;
using BL.Queries;
using BL.Repositories;
using Riganti.Utils.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using BL.DTOs;
using DAL.Entities;

namespace BL.Facades
{
    public class NotificationFacade : AppFacadeBase
    {
        public NotificationRepository NotificationRepository { get; set; }
        public IssueRepository IssueRepository { get; set; }

        public NotificationListQuery NotificationListQuery { get; set; }


        protected IQuery<NotificationDTO> CreateQuery(NotificationFilter filter)
        {
            var query = NotificationListQuery;
            query.Filter = filter;
            return query;
        }

        public List<NotificationDTO> GetAllNotifications()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new NotificationFilter { }).Execute().ToList();
            }
        }

        public List<NotificationDTO> GetNotificationsByIds(int[] ids)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appNotifications = NotificationRepository.GetByIds(ids);
                return Mapper.Map<List<NotificationDTO>>(appNotifications);
            }
        }

        public void CreateNotification(NotificationDTO notification, int issueId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalNotification = Mapper.Map<Notification>(notification);
                if (issueId > 0)
                {
                    dalNotification.Issue = IssueRepository.GetById(issueId);
                }

                NotificationRepository.Insert(dalNotification);
                uow.Commit();
            }
        }

        public void UpdateNotification(NotificationDTO notification, int issueId = 0)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appNotification = NotificationRepository.GetById(notification.Id);
                Mapper.Map(notification, appNotification);
                if (issueId > 0)
                {
                    appNotification.Issue = IssueRepository.GetById(issueId);
                }

                NotificationRepository.Update(appNotification);
                uow.Commit();
            }
        }
        public void DeleteNotification(int notificationId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                NotificationRepository.Delete(notificationId);
                uow.Commit();
            }
        }

        public bool ExistsForIssueAndUser(int issueId, int userId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var notifications = CreateQuery(new NotificationFilter { IssueId = issueId, UserId = userId }).Execute().ToList();
                return notifications.Count != 0;
            }
        }

    }
}
