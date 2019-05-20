using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.DAL;
using Final_Code_Project.Models;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class SectionSizesController : Controller
    {
        private E_ShopContext db = new E_ShopContext();

        // GET: Admin/SectionSizes
        public ActionResult Index()
        {
            var sectionSizes = db.SectionSizes.Include(s => s.Sections).Include(s => s.Sizes);
            return View(sectionSizes.ToList());
        }

        // GET: Admin/SectionSizes/Create
        public ActionResult Create()
        {
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name");
            return View();
        }

        // POST: Admin/SectionSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SectionId,SizeId")] SectionSize sectionSize)
        {
            if (ModelState.IsValid)
            {
                db.SectionSizes.Add(sectionSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", sectionSize.SectionId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", sectionSize.SizeId);
            return View(sectionSize);
        }

        // GET: Admin/SectionSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionSize sectionSize = db.SectionSizes.Find(id);
            if (sectionSize == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", sectionSize.SectionId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", sectionSize.SizeId);
            return View(sectionSize);
        }

        // POST: Admin/SectionSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SectionId,SizeId")] SectionSize sectionSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sectionSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", sectionSize.SectionId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", sectionSize.SizeId);
            return View(sectionSize);
        }

        // GET: Admin/SectionSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionSize sectionSize = db.SectionSizes.Find(id);
            if (sectionSize == null)
            {
                return HttpNotFound();
            }
            return View(sectionSize);
        }

        // POST: Admin/SectionSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SectionSize sectionSize = db.SectionSizes.Find(id);
            db.SectionSizes.Remove(sectionSize);
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
