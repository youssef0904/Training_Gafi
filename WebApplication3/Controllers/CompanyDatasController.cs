using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CompanyDatasController : Controller
    {
        private CompanyDataEntities db = new CompanyDataEntities();

        // GET: CompanyDatas
        public ActionResult Index()
        {
            var companyDatas = db.CompanyDatas.Include(c => c.LawType);
            return View(companyDatas.ToList());
        }

        // GET: CompanyDatas/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyData companyData = db.CompanyDatas.Find(id);
            if (companyData == null)
            {
                return HttpNotFound();
            }
            return View(companyData);
        }

        // GET: CompanyDatas/Create
        public ActionResult Create()
        {
            ViewBag.LawID = new SelectList(db.LawTypes, "LawTypeID", "LawTypeName");
            return View();
        }

        // POST: CompanyDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,CompanyName,EstablishDate,LawID,IssuedCapital")] CompanyData companyData)
        {
            if (ModelState.IsValid)
            {
                db.CompanyDatas.Add(companyData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LawID = new SelectList(db.LawTypes, "LawTypeID", "LawTypeName", companyData.LawID);
            return View(companyData);
        }

        // GET: CompanyDatas/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyData companyData = db.CompanyDatas.Find(id);
            if (companyData == null)
            {
                return HttpNotFound();
            }
            ViewBag.LawID = new SelectList(db.LawTypes, "LawTypeID", "LawTypeName", companyData.LawID);
            return View(companyData);
        }

        // POST: CompanyDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,CompanyName,EstablishDate,LawID,IssuedCapital")] CompanyData companyData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LawID = new SelectList(db.LawTypes, "LawTypeID", "LawTypeName", companyData.LawID);
            return View(companyData);
        }

        // GET: CompanyDatas/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyData companyData = db.CompanyDatas.Find(id);
            if (companyData == null)
            {
                return HttpNotFound();
            }
            return View(companyData);
        }

        // POST: CompanyDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            CompanyData companyData = db.CompanyDatas.Find(id);
            db.CompanyDatas.Remove(companyData);
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
