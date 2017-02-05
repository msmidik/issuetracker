using AutoMapper;
using BL.DTOs;
using DAL.Entities;


namespace BL
{
    public class Mapping
    {
        public static void Create()
        {
            Mapper.CreateMap<User, UserDTO>();
            Mapper.CreateMap<UserDTO, User>();

            Mapper.CreateMap<Employee, EmployeeDTO>();
            Mapper.CreateMap<EmployeeDTO, Employee>();

            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();

            Mapper.CreateMap<Project, ProjectDTO>();
            Mapper.CreateMap<ProjectDTO, Project>();

            Mapper.CreateMap<Issue, IssueDTO>()
                .ForMember(i => i.Type, opt => opt.MapFrom(t => (BL.Enums.IssueType)t.Type))
                .ForMember(i => i.State, opt => opt.MapFrom(t => (BL.Enums.IssueState)t.State));
            Mapper.CreateMap<IssueDTO, Issue>()
                .ForMember(i => i.Type, opt => opt.MapFrom(t => (DAL.Enums.IssueType)t.Type))
                .ForMember(i => i.State, opt => opt.MapFrom(t => (DAL.Enums.IssueState)t.State));

            Mapper.CreateMap<Comment, CommentDTO>();
            Mapper.CreateMap<CommentDTO, Comment>();

            Mapper.CreateMap<Notification, NotificationDTO>();
            Mapper.CreateMap<NotificationDTO, Notification>();

            Mapper.CreateMap<UserDTO, AppUser>();
            Mapper.CreateMap<AppUser, UserDTO>();

        }
    }
}
