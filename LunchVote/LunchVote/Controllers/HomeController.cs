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
            var todaysOptions = GetTodaysOptions();

            return View(todaysOptions);

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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private ICollection<DiningOption> GetTodaysOptions()
        {
            var todaysOptions = db.Days.Where(d => d.Date == DateTime.Today).FirstOrDefault();

            if(todaysOptions!=null)
            {
                return todaysOptions.Options;
            }

            var today = db.Days.Create();
            today.Id = Guid.NewGuid();
            today.Date = DateTime.Today;
            foreach (var location in db.Locations)
            {
                today.Options.Add(new DiningOption{Day = today, Id = Guid.NewGuid(), Location = location});
            }
            db.Days.Add(today);
            db.SaveChanges();
            return today.Options;
        }
    }
}
