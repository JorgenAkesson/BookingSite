namespace BookingSiteTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookingSiteTest.Models.DAL.BookingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookingSiteTest.Models.DAL.BookingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Cities.AddOrUpdate(
              p => p.Id,
              new BookingSiteTest.Models.City { Name = "Varberg" },
              new BookingSiteTest.Models.City { Name = "Träslövsläge" });

            context.Persons.AddOrUpdate(
                p => p.Id,
                new BookingSiteTest.Models.Person { FirstName = "Jörgen" },
                new BookingSiteTest.Models.Person { FirstName = "Ingrid" });
        }
    }
}
