using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using LunchVote.Filters;
using LunchVote.Models;

namespace LunchVote.Controllers
{
    public class LocationController : Controller
    {
        private LunchVoteContext db = new LunchVoteContext();

        //
        // GET: /Location/

        public ViewResult Index()
        {
            return View(db.Locations.ToList());
        }

        //
        // GET: /Location/Details/5

        public ViewResult Details(Guid id)
        {
            Location location = db.Locations.Find(id);
            return View(location);
        }

        //
        // GET: /Location/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Location/Create

        [HttpPost]
        public ActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                location.Id = Guid.NewGuid();
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location);
        }

        //
        // GET: /Location/Edit/5

        public ActionResult Edit(Guid id)
        {
            Location location = db.Locations.Find(id);
            return View(location);
        }

        //
        // POST: /Location/Edit/5

        [HttpPost]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        //
        // GET: /Location/Delete/5

        public ActionResult Delete(Guid id)
        {
            Location location = db.Locations.Find(id);
            return View(location);
        }

        //
        // POST: /Location/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [DayCreatedFilter]
        public PartialViewResult Nominate()
        {
            var previouslyNominated =
                db.Days.First(d => d.Date == DateTime.Today).Options.Select(o => o.Location.Id);
            
            return PartialView(db.Locations.Where(l => !previouslyNominated.Contains(l.Id)));
        }

        [HttpPost]
        [DayCreatedFilter]
        public void Nominate(Guid locationId)
        {
            var location = db.Locations.Find(locationId);
            if (location != null)
            {
                var today = db.Days.Where(d => d.Date == DateTime.Today).Single();
                if (today == null) return;
                
                // first make sure we have a collection started
                if (today.Options == null) today.Options = new List<DiningOption>();

                // if a location has already been nominated, ignore it
                if (today.Options.Any(o => o.Location.Id == location.Id))
                {
                    return;
                }
                else
                {
                    // The location selected has not yet been nominated
                    today.Options.Add(new DiningOption { Id = Guid.NewGuid(), Location = location, Votes = 0 });
                }

                db.SaveChanges();
            }
        }
    }
}