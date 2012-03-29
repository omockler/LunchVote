using System;
using System.Linq;
using System.Web.Mvc;
using LunchVote.Filters;

namespace LunchVote.Controllers
{
    public class HomeController : Controller
    {
        private LunchVoteContext db = new LunchVoteContext();

        [DayCreatedFilter]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to LunchVote!";

            //Try to get todays options
            var todaysOptions = db.Days.Where(d => d.Date == DateTime.Today).FirstOrDefault().Options;

            return View(todaysOptions);

        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        [DayCreatedFilter]
        public int Vote(Guid optionId)
        {
            var day = db.Days.Where(d => d.Date == DateTime.Today).First();
            var option = day.Options.Where(o => o.Id == optionId).First();
            option.Votes++;
            db.SaveChanges();
            return option.Votes;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
