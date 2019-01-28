using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VIDEA.ADMIN;


namespace VIDEA.ADMIN.Controllers
{
    public class TVProgramsController : Controller
    {
        private VIDEAEntities db = new VIDEAEntities();

        // GET: TVPrograms
        public ActionResult Index()
        {
            return View(db.TVPrograms.ToList());
        }

        // GET: TVPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVProgram tVProgram = db.TVPrograms.Find(id);
            if (tVProgram == null)
            {
                return HttpNotFound();
            }
            return View(tVProgram);
        }

        // GET: TVPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TVPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Network,Premiere,ShowDay,ShowTime,Rating,Expressions,Viewership,Duration,Surcharge,Cost")] TVProgram tVProgram)
        {
            if (ModelState.IsValid)
            {
                db.TVPrograms.Add(tVProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tVProgram);
        }

        // GET: TVPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVProgram tVProgram = db.TVPrograms.Find(id);
            if (tVProgram == null)
            {
                return HttpNotFound();
            }
            return View(tVProgram);
        }

        // POST: TVPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Network,Premiere,ShowDay,ShowTime,Rating,Expressions,Viewership,Duration,Surcharge,Cost")] TVProgram tVProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tVProgram);
        }

        // GET: TVPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVProgram tVProgram = db.TVPrograms.Find(id);
            if (tVProgram == null)
            {
                return HttpNotFound();
            }
            return View(tVProgram);
        }

        // POST: TVPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TVProgram tVProgram = db.TVPrograms.Find(id);
            db.TVPrograms.Remove(tVProgram);
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
