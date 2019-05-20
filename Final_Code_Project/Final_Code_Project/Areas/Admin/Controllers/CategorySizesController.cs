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
    public class CategorySizesController : Controller
    {
        private E_ShopContext db = new E_ShopContext();

        // GET: Admin/CategorySizes
        public ActionResult Index()
        {
            var categorySizes = db.CategorySizes.Include(c => c.Category).Include(c => c.Section).Include(c => c.Size);
            return View(categorySizes.ToList());
        }

        // GET: Admin/CategorySizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorySize categorySize = db.CategorySizes.Find(id);
            if (categorySize == null)
            {
                return HttpNotFound();
            }
            return View(categorySize);
        }

        // GET: Admin/CategorySizes/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name");
            return View();
        }

        // POST: Admin/CategorySizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,SectionId,SizeId")] CategorySize categorySize)
        {
            if (ModelState.IsValid)
            {
                db.CategorySizes.Add(categorySize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", categorySize.CategoryId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", categorySize.SectionId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", categorySize.SizeId);
            return View(categorySize);
        }

        // GET: Admin/CategorySizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorySize categorySize = db.CategorySizes.Find(id);
            if (categorySize == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", categorySize.CategoryId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", categorySize.SectionId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", categorySize.SizeId);
            return View(categorySize);
        }

        // POST: Admin/CategorySizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,SectionId,SizeId")] CategorySize categorySize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorySize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", categorySize.CategoryId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", categorySize.SectionId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Name", categorySize.SizeId);
            return View(categorySize);
        }

        // GET: Admin/CategorySizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorySize categorySize = db.CategorySizes.Find(id);
            if (categorySize == null)
            {
                return HttpNotFound();
            }
            return View(categorySize);
        }

        // POST: Admin/CategorySizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategorySize categorySize = db.CategorySizes.Find(id);
            db.CategorySizes.Remove(categorySize);
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
