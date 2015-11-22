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
            context.Persons.AddOrUpdate(
                p => p.FirstName,
                new BookingSiteTest.Models.Person { FirstName = "Jörgen", LastName = "Åkesson1" },
                new BookingSiteTest.Models.Person { FirstName = "Ingrid", LastName = "Åkesson" });


            //var activities = new List<Activity>();
            //activities.Add(new Activity
            //{
            //    Name = "MyActivity"
            //});

            //var calenders = new List<Calender>();
            //calenders.Add(new Calender
            //{
            //    Name = "MyCalender",
            //    Activities = activities
            //});

            context.Companies.AddOrUpdate(p => p.Name,
               new Company
               {
                   Name = "MyCompany2",
               });

            context.Calenders.AddOrUpdate(p => p.Name,
               new Calender
               {
                   CompanyID = 2,
                   Name = "MyCalender",
               });

            context.Activities.AddOrUpdate(p => p.Name,
                new Activity
                {
                    CalenderId = 3,
                    Name = "MyActivity1",
                    Date = new DateTime(2015, 11, 10),
                });

            context.Activities.AddOrUpdate(p => p.Name,
                new Activity
                {
                    CalenderId = 3,
                    Name = "MyActivity2",
                    Date = new DateTime(2015, 11, 11),
                });
        }
    }
}
