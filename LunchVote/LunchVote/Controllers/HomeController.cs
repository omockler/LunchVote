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
            var todaysOptions = db.Days.Where(d => d.Date == DateTime.Today).First();
            
            return View(todaysOptions.Options);

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
    }
}
