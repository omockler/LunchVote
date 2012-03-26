using System;
using System.Linq;
using System.Web.Mvc;
using LunchVote.Models;

namespace LunchVote.Filters
{
    public class DayCreatedFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (var db = new LunchVoteContext())
            {
                if(!db.Days.Where(d => d.Date == DateTime.Today).Any())
                {
                    db.Days.Add(new Day {Date = DateTime.Today, Id = Guid.NewGuid()});
                    db.SaveChanges();
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}