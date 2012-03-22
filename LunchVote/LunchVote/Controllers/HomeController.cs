using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LunchVote.Models;

namespace LunchVote.Controllers
{
    public class HomeController : Controller
    {
        private LunchVoteContext db = new LunchVoteContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to LunchVote!";

            //Try to get todays options
            var todaysOptions = db.Days.Where(d => d.Date == DateTime.Today);
            Day today;
            if (!todaysOptions.Any())
            {
                today = new Day
                            {
                                Date = DateTime.Today,
                                Id = Guid.NewGuid(),
                                Options = new List<DiningOption>()
                            };

                db.Days.Add(today);
                db.SaveChanges();
            }
            else
            {
                today = todaysOptions.First();
                if (today.Options == null)
                {
                    today.Options = new List<DiningOption>();
                }
            }

            return View(today.Options);

        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public void Vote(Guid optionId)
        {
            var day = db.Days.Where(d => d.Date == DateTime.Today).First();
            var option = day.Options.Where(o => o.Id == optionId).First();
            option.Votes++;
            db.SaveChanges();
        }

        public ActionResult SeedLocations()
        {
            var newLocations = new List<Location>
                                       {
                                           new Location {Id = Guid.NewGuid(), Name = "Five Guys"},
                                           new Location {Id = Guid.NewGuid(), Name = "Amore's"},
                                           new Location {Id = Guid.NewGuid(), Name = "Gumbo-A-Go-Go"},
                                           new Location {Id = Guid.NewGuid(), Name = "Chipotle"},
                                           new Location {Id = Guid.NewGuid(), Name = "Firehouse Subs"},
                                           new Location {Id = Guid.NewGuid(), Name = "Taco Bell"},
                                           new Location {Id = Guid.NewGuid(), Name = "Gyro Stop"},
                                           new Location {Id = Guid.NewGuid(), Name = "Noodles & Company"},
                                           new Location {Id = Guid.NewGuid(), Name = "Rock Bottom"},
                                           new Location {Id = Guid.NewGuid(), Name = "Buffalo Wild Wings"},
                                           new Location {Id = Guid.NewGuid(), Name = "Jersey Mike's"},
                                           new Location {Id = Guid.NewGuid(), Name = "Quizno's"},
                                           new Location {Id = Guid.NewGuid(), Name = "Penn Station"},
                                           new Location {Id = Guid.NewGuid(), Name = "Boondogglers"},
                                           new Location {Id = Guid.NewGuid(), Name = "Big Dave's Deli"},
                                           new Location {Id = Guid.NewGuid(), Name = "Charcoal Mike's"}
                                       };
            foreach (var location in newLocations)
            {
                db.Locations.Add(location);
            }

            db.SaveChanges();

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
