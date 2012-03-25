using LunchVote.Models;

namespace LunchVote.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LunchVote.LunchVoteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LunchVote.LunchVoteContext context)
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

            context.Locations.AddOrUpdate(
                l => l.Id, new Location {Id = Guid.Parse("B54A1384-BE25-4441-A516-586605E86FC8"), Name = "Five Guys"},
                new Location {Id = Guid.Parse("3AE2F746-F372-40AA-B057-19C17DD5A38E"), Name = "Amore's"},
                new Location {Id = Guid.Parse("59549A9F-0041-4283-92E6-29EA315E2FDA"), Name = "Gumbo-A-Go-Go"},
                new Location {Id = Guid.Parse("92CF3F5E-4FE7-4AB8-A633-C9EEDED56349"), Name = "Chipotle"},
                new Location {Id = Guid.Parse("41A58DA2-A5F3-4BC5-BF83-6D9542085A82"), Name = "Firehouse Subs"},
                new Location {Id = Guid.Parse("BE4DED3B-1123-4032-809F-D057FADA8E63"), Name = "Taco Bell"},
                new Location {Id = Guid.Parse("AC9CB457-BDE4-4EF5-8952-9045B619B9BB"), Name = "Gyro Stop"},
                new Location {Id = Guid.Parse("D128A047-0B7B-4FB0-BDF9-DF47B6FCF2BA"), Name = "Noodles & Company"},
                new Location {Id = Guid.Parse("B6A146A7-A50B-4694-A7F0-08AF6CAA38E4"), Name = "Rock Bottom"},
                new Location {Id = Guid.Parse("5E8DCA7E-935A-46B1-8C00-3C243506F1B7"), Name = "Buffalo Wild Wings"},
                new Location {Id = Guid.Parse("CDBA6505-4650-4FE3-993D-19CFF7F88B72"), Name = "Jersey Mike's"},
                new Location {Id = Guid.Parse("D7AFBA2E-E54D-43A0-8093-83995F524EA7"), Name = "Quizno's"},
                new Location {Id = Guid.Parse("7D90D0A4-DA62-4484-8181-E196CE5C824C"), Name = "Penn Station"},
                new Location {Id = Guid.Parse("354939B9-DE16-4AC0-8A04-B5D7B39A9815"), Name = "Boondogglers"},
                new Location {Id = Guid.Parse("B3BB786E-1F62-4153-98A3-BF196D64A0EB"), Name = "Big Dave's Deli"},
                new Location {Id = Guid.Parse("75860361-26E9-4EBF-9595-438F9604C9A4"), Name = "Charcoal Mike's"});
        }
    }
}
