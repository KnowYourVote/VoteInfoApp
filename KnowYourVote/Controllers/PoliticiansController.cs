using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnowYourVote.Models;

namespace KnowYourVote.Controllers
{
    public class PoliticiansController : Controller
    {
        private KnowYourVoteEntities db = new KnowYourVoteEntities();

        // GET: Politicians
        public ActionResult Index()
        {
            return View(db.Politicians.ToList());
        }

        // GET: Politicians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Politician politician = db.Politicians.Find(id);
            if (politician == null)
            {
                return HttpNotFound();
            }
            return View(politician);
        }

        // GET: Politicians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Politicians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoliticianID,Name")] Politician politician)
        {
            if (ModelState.IsValid)
            {
                db.Politicians.Add(politician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(politician);
        }

        // GET: Politicians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Politician politician = db.Politicians.Find(id);
            if (politician == null)
            {
                return HttpNotFound();
            }
            return View(politician);
        }

        // POST: Politicians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoliticianID,Name")] Politician politician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(politician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(politician);
        }

        // GET: Politicians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Politician politician = db.Politicians.Find(id);
            if (politician == null)
            {
                return HttpNotFound();
            }
            return View(politician);
        }

        // POST: Politicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Politician politician = db.Politicians.Find(id);
            db.Politicians.Remove(politician);
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
