using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HappinessPOC.Models;

namespace HappinessPOC.Controllers
{
    public class HappyItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HappyItems
        public ActionResult Index()
        {
            return View(db.HappyItems.ToList());
        }

        // GET: HappyItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HappyItem happyItem = db.HappyItems.Find(id);
            if (happyItem == null)
            {
                return HttpNotFound();
            }
            return View(happyItem);
        }

        // GET: HappyItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HappyItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] HappyItem happyItem)
        {
            if (ModelState.IsValid)
            {
                happyItem.Created = DateTime.UtcNow;
                db.HappyItems.Add(happyItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(happyItem);
        }

        // GET: HappyItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HappyItem happyItem = db.HappyItems.Find(id);
            if (happyItem == null)
            {
                return HttpNotFound();
            }
            return View(happyItem);
        }

        // POST: HappyItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Created")] HappyItem happyItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(happyItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(happyItem);
        }

        // GET: HappyItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HappyItem happyItem = db.HappyItems.Find(id);
            if (happyItem == null)
            {
                return HttpNotFound();
            }
            return View(happyItem);
        }

        // POST: HappyItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HappyItem happyItem = db.HappyItems.Find(id);
            db.HappyItems.Remove(happyItem);
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
