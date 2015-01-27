using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JamNotes.DAL;
using JamNotes.Models;

namespace JamNotes.Controllers
{
    public class FeaturedController : Controller
    {
        private NotesContext db = new NotesContext();

        // GET: Featured
        public ActionResult Index()
        {
            return View(db.FeaturedJams.ToList());
        }

        // GET: Featured/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturedJam featuredJam = db.FeaturedJams.Find(id);
            if (featuredJam == null)
            {
                return HttpNotFound();
            }
            return View(featuredJam);
        }

        // GET: Featured/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Featured/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeaturedJamID,Title,Author,DatePublished,Content")] FeaturedJam featuredJam)
        {
            if (ModelState.IsValid)
            {
                db.FeaturedJams.Add(featuredJam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(featuredJam);
        }

        // GET: Featured/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturedJam featuredJam = db.FeaturedJams.Find(id);
            if (featuredJam == null)
            {
                return HttpNotFound();
            }
            return View(featuredJam);
        }

        // POST: Featured/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeaturedJamID,Title,Author,DatePublished,Content")] FeaturedJam featuredJam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(featuredJam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(featuredJam);
        }

        // GET: Featured/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeaturedJam featuredJam = db.FeaturedJams.Find(id);
            if (featuredJam == null)
            {
                return HttpNotFound();
            }
            return View(featuredJam);
        }

        // POST: Featured/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeaturedJam featuredJam = db.FeaturedJams.Find(id);
            db.FeaturedJams.Remove(featuredJam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
