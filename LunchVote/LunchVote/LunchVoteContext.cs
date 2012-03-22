using System.Data.Entity;
using LunchVote.Models;

namespace LunchVote
{
    public class LunchVoteContext : DbContext
    {
        public DbSet<DiningOption> Options { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Day> Days { get; set; }
    }
}