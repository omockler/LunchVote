using System;
using System.Linq;
using System.Web.Mvc;
using LunchVote.Models;

namespace LunchVote.Filters
{
    public class DayCreatedFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// Used to ensure that there is a record created in the database for the current day.
        /// If there isn't a new day is created.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (var db = new LunchVoteContext())
            {
                if (!db.Days.Where(d => d.Date == DateTime.Today).Any())
                {
                    db.Days.Add(new Day
                                    {
                                        Date = DateTime.Today,
                                        Id = Guid.NewGuid()
                                    });

                    db.SaveChanges();
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}