using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LunchVote.Models;
using LunchVote;

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

        public PartialViewResult Nominate()
        {
            return PartialView(db.Locations);
        }

        [HttpPost]
        public void Nominate(Guid locationId)
        {
            var location = db.Locations.Where(l => l.Id == locationId);
            if (location.Any())
            {
                var today = db.Days.Where(d => d.Date == DateTime.Today).Single();
                var nomination = new DiningOption {Id = Guid.NewGuid(), Location = location.First()};
                if (today.Options != null)
                {
                    today.Options.Add(nomination);
                    
                }
                else
                {
                    today.Options = new List<DiningOption> {nomination};
                }
                
                db.SaveChanges();
            }
        }
    }
}