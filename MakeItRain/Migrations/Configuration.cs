namespace MakeItRain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MakeItRain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MakeItRain.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MakeItRain.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Users.AddOrUpdate(
                p => p.Id,
                new User {Id = "asdf"});
            context.SaveChanges();

            context.CalendarEvents.AddOrUpdate(
                p => p.ID,
                new CalendarEvent
                {
                    UserID = "asdf",
                    ID = 1,
                    Start = new DateTime(2014, 5, 4, 13, 0, 0),
                    End = new DateTime(2014, 5, 4, 15, 0, 0),
                    Title = "Test Event",
                    Description = "This is a test"
                });
            context.SaveChanges();

            context.StockTransactions.AddOrUpdate(
                p => p.ID,
                new StockTransaction
                {
                    UserID = "asdf",
                    ID = 1,
                    StockID = "GOOG",
                    StockName = "Google",
                    StockAmount = 100,
                    StockPrice = 25.65,
                    Timestamp = new DateTime(2014,5,5,12,25,0,0)
                });
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
        }
    }
}
