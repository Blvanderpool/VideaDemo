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
    public class CampaignsController : Controller
    {
        private VIDEAEntities db = new VIDEAEntities();

        // GET: Campaigns
        public ActionResult Index()
        {
            return View(db.Campaigns.ToList());
        }

        // GET: Campaigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = db.Campaigns.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // GET: Campaigns/Create
        public ActionResult Create()
        {
            var stageList = new List<SelectListItem>();

            stageList.Add(new SelectListItem { Value = "", Text = "Select a Stage" });
            stageList.Add(new SelectListItem { Value = "INITIAL", Text = "Initial" });
            stageList.Add(new SelectListItem { Value = "DESIGN", Text = "Design" });
            stageList.Add(new SelectListItem { Value = "INPROGRESS", Text = "In Progress" });

            ViewBag.StageOptions = stageList; // GetStageList();

            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Budget,Stage,CampaignStart,CampaignEnd")] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                db.Campaigns.Add(campaign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campaign);
        }

        // GET: Campaigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = db.Campaigns.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Budget,Stage,CampaignStart,CampaignEnd")] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campaign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campaign campaign = db.Campaigns.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campaign campaign = db.Campaigns.Find(id);
            db.Campaigns.Remove(campaign);
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

        public List<SelectListItem> GetStageList() //= new List<SelectListItem>()
        {  
           var stageList = new List<SelectListItem>();

            stageList.Add(new SelectListItem { Value = "", Text = "Select a Stage" });
            stageList.Add( new SelectListItem { Value = "INITIAL", Text = "Initial" });
            stageList.Add( new SelectListItem { Value = "DESIGN", Text = "Design" });
            stageList.Add( new SelectListItem { Value = "INPROGRESS", Text = "In Progress" });
            
            return stageList;
        }

 

    }
}
