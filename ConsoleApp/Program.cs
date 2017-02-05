using System;
using System.Collections.Generic;
using DAL;
using BL;
using BL.Facades;
using BL.DTOs;
using Castle.Windsor;
using System.Linq;
using BL.Enums;

namespace ConsoleApp
{
    class Program
    {
        private static IWindsorContainer container;

        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {

                Console.WriteLine("Using DAL:");
                Console.WriteLine("Customers:");
                PrintOnConsole(context.Customers);
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine();
                
                Console.WriteLine("Using BL:");
                Console.WriteLine();
                PerformStartup();

                TestCustomerFacade();
                TestEmployeeFacade();
                TestProjectFacade();
                TestIssueFacade();
                TestCommentFacade();
                TestNotificationFacade();


                Console.ReadKey();
                
            }
        }

        private static CustomerDTO customer;
        private static ProjectDTO project;
        private static IssueDTO issue;

        public static void TestCustomerFacade()
        {
            var cf = container.Resolve<CustomerFacade>();
            // CreateCustomer
              cf.CreateCustomer(
                new CustomerDTO { Name = "novy zakaznik", Email = "new@cz.cz"});
            
            // GetCustomersByIds
            customer = cf.GetCustomersByIds(new int[] { 1 }).ElementAt(0);

            // UpdateCustomer
            customer.Name = "updated name";
            cf.UpdateCustomer(customer);

            // GetAllCustomers
            var customers = cf.GetAllCustomers();
            Console.WriteLine("Customers:");
            PrintOnConsole(customers);
        }

        private static void TestEmployeeFacade()
        {
            var ef = container.Resolve<EmployeeFacade>();
            // CreateEmployee
            ef.CreateEmployee(
              new EmployeeDTO { FirstName = "Bob", Surname = "Doe", Email = "bob@doe.cz" });

            // GetEmplyeesByIds
            var emloyee = ef.GetEmployeesByIds(new int[] { 7 }).ElementAt(0);

            // UpdateEmployee
            emloyee.FirstName = "updated-firstname";
            ef.UpdateEmployee(emloyee);

            // GetAllEmployees
            var employees = ef.GetAllEmployees();
            Console.WriteLine("Employees:");
            PrintOnConsole(employees);
        }

        private static void TestProjectFacade()
        {
            var pf = container.Resolve<ProjectFacade>();
            // Create
            pf.CreateProject(
              new ProjectDTO { Name = "Calculator"},
              customer.Id);

            // GetByIds
            project = pf.GetProjectsByIds(new int[] { 1 }).ElementAt(0);

            // Update
            project.Name = "updated-projectname";
            pf.UpdateProject(project);

            // GetAll
            var projects = pf.GetAllProjects();
            Console.WriteLine("Projects:");
            PrintOnConsole(projects);
        }


        private static void TestIssueFacade()
        {
            var isf = container.Resolve<IssueFacade>();
            // Create
            isf.CreateIssue(
              new IssueDTO
              {
                  Name = "Nejde tisk",
                  Description = "vážně nejde tisknout",
                  Type = IssueType.Error,
                  State = IssueState.New,
                  ApplicationDate = new DateTime(2016, 4, 30),
                  Informer = "anonym"
              },
              project.Id);

            // GetByIds
            issue = isf.GetIssuesByIds(new int[] { 1 }).ElementAt(0);
            issue = isf.GetIssueByType(IssueType.Error).ElementAt(0);

            // Update
           issue.Name = "updated-issue";
            isf.UpdateIssue(issue);

            // GetAll
            var issues = isf.GetAllIssues();
            Console.WriteLine("Issues:");
            PrintOnConsole(issues);
        }

        private static void TestCommentFacade()
        {
            var cf = container.Resolve<CommentFacade>();
            // Create
            cf.CreateComment(
              new CommentDTO { Text = "koukejte to opravit", AuthorId = customer.Id },
              issue.Id);

            // GetByIds
            var comment = cf.GetCommentsByIds(new int[] { 1 }).ElementAt(0);

            // Update
            comment.Text = "updated-comment";
            comment.Issue = issue;
            cf.UpdateComment(comment);

            // GetAll
            var comments = cf.GetAllComments();
            Console.WriteLine("Comments:");
            PrintOnConsole(comments);
        }

        private static void TestNotificationFacade()
        {
            var nf = container.Resolve<NotificationFacade>();
            // Create
            nf.CreateNotification(
              new NotificationDTO { SendEmail = true, UserId = customer.Id },
              issue.Id);

            // GetByIds
            var notification = nf.GetNotificationsByIds(new int[] { 1 }).ElementAt(0);

            // Update
            notification.SendEmail = false;
            notification.Issue = issue;
            nf.UpdateNotification(notification);

            // GetAll
            var notifications = nf.GetAllNotifications();
            Console.WriteLine("Notifications:");
            PrintOnConsole(notifications);
        }

        private static void PrintOnConsole(IEnumerable<object> list)
        {
            foreach (object o in list)
            {
                Console.WriteLine(o);
            }
        }

        private static void PerformStartup()
        {
            container = new WindsorContainer();
            container.Install(new Installer());
        }



    }
}
