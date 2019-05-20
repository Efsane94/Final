using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.DAL;
using Final_Code_Project.Models;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class SectionCategoryController : Controller
    {
        private readonly E_ShopContext db;

        public SectionCategoryController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/CategorySection
        public ActionResult Index()
        {
            return View(db.SectionCategories.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.sections = db.Sections.ToList();
            ViewBag.categories = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int? sectionId, int? categoriId, SectionCategory sectionCategory)
        {
            ViewBag.sections = db.Sections.ToList();
            ViewBag.categories = db.Categories.ToList();

            if (sectionId == null || categoriId == null)
            {
                ModelState.AddModelError("allError", "Please Enter All Info");
                return View(sectionCategory);
            }
            sectionCategory.SectionId = (int)sectionId;
            sectionCategory.CategoryId = (int)categoriId;

            var dbcheck = db.Sections.Find(sectionId);
            var dbcheck2 = db.Categories.Find(categoriId);

            if (dbcheck == null || dbcheck2 == null)
            {
                ModelState.AddModelError("allError", "Null Database Data");
                return View(sectionCategory);
            }

            if (!ModelState.IsValid) return View(sectionCategory);

            db.SectionCategories.Add(sectionCategory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                ModelState.AddModelError("allError", "Id is not found");
            }
            ViewBag.sections = db.Sections.ToList();
            ViewBag.categories = db.Categories.ToList();
            var s_cat = db.SectionCategories.Find(Id);
            if (s_cat == null)
            {
                ModelState.AddModelError("allError", "Section Category is not found");
            }
            return View(s_cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SectionId,CategoryId")] SectionCategory s_category)
        {
            ViewBag.sections = db.Sections.ToList();
            ViewBag.categories = db.Categories.ToList();

            if (!ModelState.IsValid) return View(s_category);

            var dbcheck = db.Sections.Find(s_category.SectionId);
            var dbcheck2 = db.Sections.Find(s_category.CategoryId);

            if (dbcheck == null || dbcheck2 == null)
            {
                ModelState.AddModelError("alError", "Plese,Enter the information correctly");
            }

            SectionCategory s_cat = db.SectionCategories.Find(s_category.Id);

            s_cat.SectionId = s_category.SectionId;
            s_cat.CategoryId = s_category.CategoryId;

            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionCategory sectionCat = db.SectionCategories.Find(id);
            if (sectionCat == null)
            {
                return HttpNotFound();
            }
            return View(sectionCat);
        }

        // POST: Admin/CategorySizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SectionCategory sectionC = db.SectionCategories.Find(id);
            db.SectionCategories.Remove(sectionC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}