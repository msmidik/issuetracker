using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Entities;
using DAL.Enums;

namespace DAL
{
    class DataInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            var customer1 = new Customer { Name = "Josef Novak", Email = "josef@novak.cz" };
            var customer2 = new Customer { Name = "Firma s.r.o.", Email = "info@firma.cz" };
            var customer3 = new Customer { Name = "Spolecnost a.s.", Email = "info@spolecnost.cz" };
            var customer4 = new Customer { Name = "Policie ČR", Email = "info@policie.cz" };
            var project1 = new Project { Name = "Úprava webu", Customer = customer1 };
            var project2 = new Project { Name = "IS pro Firma s.r.o.", Customer = customer2 };
            var project3 = new Project { Name = "IS Spolecnost a.s.", Customer = customer3 };
            var project4 = new Project { Name = "Web Spolecnost a.s.", Customer = customer3 };
            var project5 = new Project { Name = "Tajný projekt", Customer = customer4 };

            var employee1 = new Employee { FirstName = "Martin", Surname = "Schmidt", Email = "ms@zamestnec.cz" };
            var employee2 = new Employee { FirstName = "Ondřej", Surname = "Dvořák", Email = "od@zamestnec.cz" };
            var employee3 = new Employee { FirstName = "John", Surname = "Doe", Email = "jd@zamestnec.cz" };

            context.Roles.Add(new AppRole { Name = "Administrator" });

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);
            context.Customers.Add(customer4);
            context.Projects.Add(project1);
            context.Projects.Add(project2);
            context.Projects.Add(project3);
            context.Projects.Add(project4);
            context.Projects.Add(project5);
            context.Employees.Add(employee1);
            context.Employees.Add(employee2);
            context.Employees.Add(employee3);

            var issue1 = new Issue
            {
                Name = "Je to rozbitý",
                Description = "nic nefuguje",
                Type = IssueType.Error,
                State = IssueState.InProcess,
                ApplicationDate = new DateTime(2016, 4, 20),
                Informer = "anonym",
                Project = project2,
                Solver = employee1
            };
            context.Issues.Add(issue1);

            var issue2 = new Issue
            {
                Name = "Podpora linuxu",
                Description = "požadujeme verzi pro linux",
                Type = IssueType.Request,
                State = IssueState.New,
                ApplicationDate = new DateTime(2016, 5, 20),
                Informer = "ředitel",
                Project = project2
            };

            var issue3 = new Issue
            {
                Name = "Tajné",
                Description = "požadujeme více tajných funkcí do tajného systému",
                Type = IssueType.Request,
                State = IssueState.New,
                ApplicationDate = new DateTime(2016, 5, 15),
                Informer = "náčelník",
                Project = project5
            };

            context.Issues.Add(issue1);
            context.Issues.Add(issue2);
            context.Issues.Add(issue3);

            context.SaveChanges();
            base.Seed(context);

        }
    }
}
