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
