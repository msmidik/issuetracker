using AutoMapper;
using BL.Queries;
using BL.Repositories;
using Riganti.Utils.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using BL.DTOs;
using DAL.Entities;
using BL.Enums;
using BL.Services;

namespace BL.Facades
{
    public class IssueFacade : AppFacadeBase
    {
        public IssueRepository IssueRepository { get; set; }
        public ProjectRepository ProjectRepository { get; set; }
        public EmployeeRepository EmployeeRepository { get; set; }

        public IssueListQuery IssueListQuery { get; set; }

        private IEmailService emailService = new FakeEmailService();

        protected IQuery<IssueDTO> CreateQuery(IssueFilter filter)
        {
            var query = IssueListQuery;
            query.Filter = filter;
            return query;
        }

        public List<IssueDTO> GetAllIssues()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new IssueFilter { }).Execute().ToList();
            }
        }

        public List<IssueDTO> GetIssuesByIds(int[] ids)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appIssues = IssueRepository.GetByIds(ids);
                return Mapper.Map<List<IssueDTO>>(appIssues);
            }
        }

        public void CreateIssue(IssueDTO issue, int projectId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalIssue = Mapper.Map<Issue>(issue);
                if (projectId > 0)
                {
                    dalIssue.Project = ProjectRepository.GetById(projectId);
                }

                IssueRepository.Insert(dalIssue);
                uow.Commit();
            }
        }

        public void UpdateIssue(IssueDTO issue, int projectId = 0, int employeeId = 0)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appIssue = IssueRepository.GetById(issue.Id);
                Mapper.Map(issue, appIssue);
                if (projectId > 0)
                {
                    appIssue.Project = ProjectRepository.GetById(projectId);
                }
                if (employeeId > 0)
                {
                    appIssue.Solver = EmployeeRepository.GetById(employeeId);
                }

                IssueRepository.Update(appIssue);
                uow.Commit();
            }
        }

        public List<IssueDTO> GetIssueByProject(int projectId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new IssueFilter { ProjectId = projectId }).Execute().ToList();
            }
        }

        public List<IssueDTO> GetIssueByProjectAndType(int projectId, IssueType issueType)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new IssueFilter { ProjectId = projectId , IssueType = issueType}).Execute().ToList();
            }
        }

        public List<IssueDTO> GetIssueByProjectAndState(int projectId, IssueState issueState)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new IssueFilter { ProjectId = projectId, IssueState = issueState }).Execute().ToList();
            }
        }

        public List<IssueDTO> GetIssueByType(IssueType issueType)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new IssueFilter { IssueType = issueType }).Execute().ToList();
            }
        }

        public List<IssueDTO> GetIssueByState(IssueState issueState)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new IssueFilter { IssueState = issueState }).Execute().ToList();
            }
        }

        public List<IssueDTO> GetIssueByTypeAndState(IssueType issueType, IssueState issueState)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new IssueFilter { IssueType = issueType, IssueState = issueState }).Execute().ToList();
            }
        }

        public void DeleteIssue(int issueId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                IssueRepository.Delete(issueId);
                uow.Commit();
            }
        }

        public void SendEmail(string text)
        {
            emailService.Send(text);
        }

    }
}
