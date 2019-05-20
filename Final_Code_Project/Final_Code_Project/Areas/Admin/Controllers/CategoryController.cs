using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.DAL;
using Final_Code_Project.Models;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoryController : Controller
    {
        private readonly E_ShopContext db;

        public CategoryController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] Category category)
        {
            if (!ModelState.IsValid) return View(category);

            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var category = db.Categories.Find(Id);

            if (category == null) return HttpNotFound("Category is not found");

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (!ModelState.IsValid) return View(category);

            Category categoryDb = db.Categories.Find(category.Id);

            categoryDb.Name = category.Name;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var category = db.Categories.Find(Id);

            if (category == null) return HttpNotFound("Category is not found");

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteCategory(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var categoryDb = db.Categories.Find(Id);

            if (categoryDb == null) return HttpNotFound("Customer is not found");

            db.Categories.Remove(categoryDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}