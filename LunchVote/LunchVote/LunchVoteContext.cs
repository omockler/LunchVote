using System.Data.Entity;
using LunchVote.Models;

namespace LunchVote
{
    public class LunchVoteContext : DbContext
    {
        public LunchVoteContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LunchVoteContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LunchVoteContext, Migrations.Configuration>());
            Database.Initialize(false);
        }

        public DbSet<DiningOption> Options { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Day> Days { get; set; }
    }
}