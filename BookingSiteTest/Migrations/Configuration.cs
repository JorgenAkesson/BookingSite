namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookingSiteTest.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<BookingSiteTest.Models.DAL.BookingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookingSiteTest.Models.DAL.BookingContext context)
        {
            context.Companies.AddOrUpdate(p => p.Name,
               new Company
               {
                   Name = "MyCompany1",
               });

            context.SaveChanges();

            var comp1 = context.Companies.FirstOrDefault(a => a.Name == "MyCompany1");

            context.Calenders.AddOrUpdate(p => p.Name,
               new Calender
               {
                   CompanyID = comp1.Id,
                   Name = "MyCalender1",
               });

            context.SaveChanges();

            var cal1 = context.Calenders.FirstOrDefault(a => a.Name == "MyCalender1");

            context.Activities.AddOrUpdate(p => p.Name,
                new Activity
                {
                    CalenderId = cal1.Id,
                    Name = "MyActivity1",
                    Date = DateTime.Now,
                    MaxPerson = 2,
                    Duration = 30,
                });

            context.Activities.AddOrUpdate(p => p.Name,
                new Activity
                {
                    CalenderId = cal1.Id,
                    Name = "MyActivity2",
                    Date = DateTime.Now.AddHours(2),
                    MaxPerson = 2,
                    Duration = 30,
                });

            context.Activities.AddOrUpdate(p => p.Name,
            new Activity
            {
                CalenderId = cal1.Id,
                Name = "MyActivity3",
                Date = DateTime.Now.AddDays(1),
                MaxPerson = 2,
                Duration = 30,
            });

            context.Activities.AddOrUpdate(p => p.Name,
            new Activity
            {
                CalenderId = cal1.Id,
                Name = "MyActivity4",
                Date = DateTime.Now.AddDays(2).AddHours(2),
                MaxPerson = 2,
                Duration = 30,
            });
        }
    }
}
