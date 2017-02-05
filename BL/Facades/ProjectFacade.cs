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
    public class ProjectFacade : AppFacadeBase
    {
        public ProjectRepository ProjectRepository { get; set; }
        public CustomerRepository CustomerRepository { get; set; }

        public ProjectListQuery ProjectListQuery { get; set; }


        protected IQuery<ProjectDTO> CreateQuery()
        {
            var query = ProjectListQuery;
            return query;
        }

        public List<ProjectDTO> GetAllProjects()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery().Execute().ToList();
            }
        }

        public List<ProjectDTO> GetProjectsByIds(int[] ids)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appProjects = ProjectRepository.GetByIds(ids);
                return Mapper.Map<List<ProjectDTO>>(appProjects);
            }
        }

        public void CreateProject(ProjectDTO project, int customerId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalProject = Mapper.Map<Project>(project);
                if (customerId > 0)
                {
                    dalProject.Customer = CustomerRepository.GetById(customerId);
                }
                ProjectRepository.Insert(dalProject);
                uow.Commit();
            }
        }

        public void UpdateProject(ProjectDTO project, int customerId = 0)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appProject = ProjectRepository.GetById(project.Id);
                Mapper.Map(project, appProject);
                if (customerId > 0)
                {
                    appProject.Customer = CustomerRepository.GetById(customerId);
                }
                ProjectRepository.Update(appProject);
                uow.Commit();
            }
        }

        public void DeleteProject(int projectId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                ProjectRepository.Delete(projectId);
                uow.Commit();
            }
        }

    }
}
