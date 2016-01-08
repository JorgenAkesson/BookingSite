using BookingSiteTest.Models;
using BookingSiteTest.Views.Calender;

namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookingSiteTest.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookingSiteTest.Models.UsersContext context)
        {
            //
            // Users and roles
            //
            var userContext = new BookingSiteTest.Models.UsersContext();
            userContext.UserProfiles.AddOrUpdate(p => p.UserName,
                new UserProfile()
                {
                    UserName = "admin",
                    FirstName = "Jörgen",
                    LastName = "Åkesson",
                    Email = "jorg.akesson@gmail.com",
                    Phone = "0702732400",
                });
            userContext.SaveChanges();

            userContext.UserProfiles.AddOrUpdate(p => p.UserName,
                new UserProfile()
                {
                    UserName = "cadmin",
                    FirstName = "Ingrid",
                    LastName = "Åkesson",
                    Email = "ingakesson@gmail.com",
                    Phone = "0340219316",
                });
            userContext.SaveChanges();

            userContext.UserProfiles.AddOrUpdate(p => p.UserName,
                new UserProfile()
                {
                    UserName = "user",
                    FirstName = "Sture",
                    LastName = "Åkesson",
                    Email = "stugun@gmail.com",
                    Phone = "034030514",
                });
            userContext.SaveChanges();
            var regularUser = userContext.UserProfiles.First(a => a.UserName == "user");

            userContext.Role.AddOrUpdate(p => p.RoleName,
                new Role()
                {
                    RoleName = "admin"
                });
            userContext.SaveChanges();

            userContext.Role.AddOrUpdate(p => p.RoleName,
                new Role()
                {
                    RoleName = "companyAdmin"
                });
            userContext.SaveChanges();


            var adminUser = userContext.UserProfiles.First(a => a.UserName == "admin");
            var adminRole = userContext.Role.First(a => a.RoleName == "admin");
            userContext.UserInRole.AddOrUpdate(p => p.UserId,
                new UserInRole()
                {
                    UserId = adminUser.UserId,
                    RoleId = adminRole.RoleId,
                });
            userContext.SaveChanges();

            var companyAdminUser = userContext.UserProfiles.First(a => a.UserName == "cadmin");
            var companyAdminRole = userContext.Role.First(a => a.RoleName == "companyAdmin");
            userContext.UserInRole.AddOrUpdate(p => p.UserId,
                new UserInRole()
                {
                    UserId = companyAdminUser.UserId,
                    RoleId = companyAdminRole.RoleId,
                });
            userContext.SaveChanges();

            // Admin user
            userContext.Membership.AddOrUpdate(p => p.UserId,
                new Membership()
                {
                    UserId = adminUser.UserId,
                    CreateDate = DateTime.Now,
                    //ConfirmationToken = "",
                    IsConfirmed = true,
                    LastPasswordFailureDate = DateTime.Now,
                    PasswordFailuresSinceLastSuccess = 0,
                    Password = "ABbz4fd9+hK7xRweDyQz+5qMYoNAlZPr9Y9RuKZ+/LQFWjQ7SjbtkDnYNqUcngkNcg==",
                    PasswordChangedDate = DateTime.Now,
                    PasswordSalt = "",
                    //PasswordVerificationToken = "",
                    PasswordVerificationTokenExpirationDate = DateTime.Now,
                });
            userContext.SaveChanges();

            // cadmin user
            userContext.Membership.AddOrUpdate(p => p.UserId,
                new Membership()
                {
                    UserId = companyAdminUser.UserId,
                    CreateDate = DateTime.Now,
                    //ConfirmationToken = "",
                    IsConfirmed = true,
                    LastPasswordFailureDate = DateTime.Now,
                    PasswordFailuresSinceLastSuccess = 0,
                    Password = "AGPpkFLEmgzVsvqnyGyOvs1l7nLAG3SseAUFl6Xxd8epeKNtetmdry/4bsf61M4ejw==",
                    PasswordChangedDate = DateTime.Now,
                    PasswordSalt = "",
                    //PasswordVerificationToken = "",
                    PasswordVerificationTokenExpirationDate = DateTime.Now,
                });
            userContext.SaveChanges();

            // regular user
            userContext.Membership.AddOrUpdate(p => p.UserId,
                new Membership()
                {
                    UserId = regularUser.UserId,
                    CreateDate = DateTime.Now,
                    //ConfirmationToken = "",
                    IsConfirmed = true,
                    LastPasswordFailureDate = DateTime.Now,
                    PasswordFailuresSinceLastSuccess = 0,
                    Password = "AJQgSUI3ho7JpWf5Gm4x+4wUqBmE6WFbIgotOTAjSoxJw47S0J2HPPGW/EEd9u5fWA==",
                    PasswordChangedDate = DateTime.Now,
                    PasswordSalt = "",
                    //PasswordVerificationToken = "",
                    PasswordVerificationTokenExpirationDate = DateTime.Now,
                });
            userContext.SaveChanges();

            //
            // Addresses
            //
            context.Addresses.AddOrUpdate(p => p.Name,
               new Address()
               {
                   Name = "MyAddress2",
                   Street = "MyStreet2",
                   PostalNumber = "456 78",
                   City = "MyCity2",
               });
            var id = context.SaveChanges();

            var address2 = context.Addresses.FirstOrDefault(a => a.Name == "MyAddress2");

            context.Companies.AddOrUpdate(p => p.Name,
               new Company
               {
                   Name = "MyCompany2",
                   AddressId = address2.Id,
               });
            id = context.SaveChanges();

            var comp2 = context.Companies.FirstOrDefault(a => a.Name == "MyCompany2");

            context.Calenders.AddOrUpdate(p => p.Name,
               new Calender
               {
                   CompanyID = comp2.Id,
                   Name = "MyCalender2",
               });
            id = context.SaveChanges();

            var cal2 = context.Calenders.FirstOrDefault(a => a.Name == "MyCalender2");

            var date = DateTime.Now;
            var datePlusOne = DateTime.Now.AddDays(1);
            var newDate = new DateTime(date.Year, date.Month, date.Day, 11, 00, 00);
            context.Activities.AddOrUpdate(p => p.Name,
                new Activity
                {
                    CalenderId = cal2.Id,
                    Name = "MyActivity2-1",
                    Date = newDate,
                    MaxPerson = 2,
                    Duration = 60,
                    Time = "11:00",
                });

            context.Addresses.AddOrUpdate(p => p.Name,
               new Address()
               {
                   Name = "Åkesson IT AB c/o Jörgen Åkesson",
                   Street = "Babordsvägen 11",
                   PostalNumber = "432 74",
                   City = "Träslövsläge",
               });
            id = context.SaveChanges();

            var address1 = context.Addresses.FirstOrDefault(a => a.Name == "Åkesson IT AB c/o Jörgen Åkesson");

            context.Companies.AddOrUpdate(p => p.Name,
               new Company
               {
                   Name = "Åkesson IT AB",
                   Email = "jorg.akesson@gmail.com",
                   Phone = "070-2732400",
                   Description = "It konsult företag med inriktning på web och windows utveckling.",
                   WebPage = "http://akessonit.se",
                   AddressId = address1.Id,
               });
            id = context.SaveChanges();

            var comp1 = context.Companies.FirstOrDefault(a => a.Name == "Åkesson IT AB");

            context.Calenders.AddOrUpdate(p => p.Name,
               new Calender
               {
                   CompanyID = comp1.Id,
                   Name = "Development",
               });
            id = context.SaveChanges();

            var cal1 = context.Calenders.FirstOrDefault(a => a.Name == "Development");

            date = DateTime.Now;
            newDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            context.Activities.AddOrUpdate(p => p.Name,
                new Activity
                {
                    CalenderId = cal1.Id,
                    Name = ".NET kurs",
                    Date = newDate,
                    MaxPerson = 2,
                    Duration = 60,
                    Time = "12:00",
                });

            newDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            context.Activities.AddOrUpdate(p => p.Name,
                new Activity
                {
                    CalenderId = cal1.Id,
                    Name = "C# kurs",
                    Date = newDate,
                    MaxPerson = 2,
                    Duration = 60,
                    Time = "14:00",
                });

            newDate = new DateTime(datePlusOne.Year, datePlusOne.Month, datePlusOne.Day, 0, 0, 0);
            context.Activities.AddOrUpdate(p => p.Name,
            new Activity
            {
                CalenderId = cal1.Id,
                Name = "IT konsultation",
                Date = newDate,
                MaxPerson = 2,
                Duration = 60,
                Time = "14:00",
            });

            newDate = new DateTime(datePlusOne.Year, datePlusOne.Month, datePlusOne.Day, 0, 0, 0);
            context.Activities.AddOrUpdate(p => p.Name,
            new Activity
            {
                CalenderId = cal1.Id,
                Name = "Office utbildning",
                Date = newDate,
                MaxPerson = 2,
                Duration = 60,
                Time = "16:00",
            });
        }
    }
}
