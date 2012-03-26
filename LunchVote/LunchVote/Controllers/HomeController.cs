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
            var todaysOptions = GetTodaysOptions();

            return View(todaysOptions);

        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
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
            
            db.Days.Add(today);
            db.SaveChanges();
            return today.Options;
        }
    }
}
