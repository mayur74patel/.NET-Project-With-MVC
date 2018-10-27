using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class PoliticsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Politics
        public ActionResult Index(string searchString, string sortOrder)
        {
			ViewBag.VordId = string.IsNullOrEmpty(sortOrder) ? "Vord_dec" : "";
			ViewBag.VordName= string.IsNullOrEmpty(sortOrder) ? "V_d" : "Vord_name";
			var Politics = from e in db.Politics
						   select e;
			if (!string.IsNullOrEmpty(searchString))
			{
				Politics = Politics.Where(x => x.VordName == searchString || x.PolitianName1 ==searchString || x.PolitianName2== searchString);
			}
			switch (sortOrder)
			{
				case "Vord_dec":
					Politics = Politics.OrderByDescending(x => x.VordId);
					break;
				case "Vord_name":
					Politics = Politics.OrderByDescending(x => x.VordName);
					break;
			}
			return View(Politics);
        }

        // GET: Politics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Politics politics = db.Politics.Find(id);
            if (politics == null)
            {
                return HttpNotFound();
            }
            return View(politics);
        }

        // GET: Politics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Politics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoliticsId,StateId,VordId,VordName,PolitianName1,PolitianParty1,PolitianName2,PolitianParty2,PolitianResult")] Politics politics)
        {
            if (ModelState.IsValid)
            {
                db.Politics.Add(politics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(politics);
        }

        // GET: Politics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Politics politics = db.Politics.Find(id);
            if (politics == null)
            {
                return HttpNotFound();
            }
            return View(politics);
        }

        // POST: Politics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoliticsId,StateId,VordId,VordName,PolitianName1,PolitianParty1,PolitianName2,PolitianParty2,PolitianResult")] Politics politics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(politics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(politics);
        }

        // GET: Politics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Politics politics = db.Politics.Find(id);
            if (politics == null)
            {
                return HttpNotFound();
            }
            return View(politics);
        }

        // POST: Politics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Politics politics = db.Politics.Find(id);
            db.Politics.Remove(politics);
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
