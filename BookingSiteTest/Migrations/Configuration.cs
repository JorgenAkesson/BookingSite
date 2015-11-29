using BookingSiteTest.Views.Calender;

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
            context.Addresses.AddOrUpdate(p => p.Name,
               new Address()
               {
                   Name = "MyAddress1",
                   Street = "MyStreet1",
                   PostalNumber = "123 45",
                   City = "MyCity1",
               });
            context.SaveChanges();

            var address1 = context.Addresses.FirstOrDefault(a => a.Name == "MyAddress1");

            context.Companies.AddOrUpdate(p => p.Name,
               new Company
               {
                   Name = "MyCompany1",
                   AddressId = address1.Id,
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

            var date = DateTime.Now;
            var newDate = new DateTime(date.Year, date.Month, date.Day, 12, 00, 00);
            context.Activities.AddOrUpdate(p => p.Name,
                new Activity
                {
                    CalenderId = cal1.Id,
                    Name = "MyActivity1",
                    Date = newDate,
                    MaxPerson = 2,
                    Duration = 30,
                });

            newDate = new DateTime(date.Year, date.Month, date.Day, 14, 00, 00);
            context.Activities.AddOrUpdate(p => p.Name,
                new Activity
                {
                    CalenderId = cal1.Id,
                    Name = "MyActivity2",
                    Date = newDate,
                    MaxPerson = 2,
                    Duration = 30,
                });

            newDate = new DateTime(date.Year, date.Month, date.Day + 1, 14, 00, 00);
            context.Activities.AddOrUpdate(p => p.Name,
            new Activity
            {
                CalenderId = cal1.Id,
                Name = "MyActivity3",
                Date = newDate,
                MaxPerson = 2,
                Duration = 30,
            });

            newDate = new DateTime(date.Year, date.Month, date.Day + 1, 16, 00, 00);
            context.Activities.AddOrUpdate(p => p.Name,
            new Activity
            {
                CalenderId = cal1.Id,
                Name = "MyActivity4",
                Date = newDate,
                MaxPerson = 2,
                Duration = 30,
            });
        }
    }
}
