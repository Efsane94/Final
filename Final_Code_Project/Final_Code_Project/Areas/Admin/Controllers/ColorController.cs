using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.Models;
using Final_Code_Project.DAL;
using System.Threading.Tasks;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class ColorController : Controller
    {
        private readonly E_ShopContext db;

        public ColorController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/Color
        public ActionResult Index()
        {
            return View(db.Colors.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] Color color)
        {
            if (!ModelState.IsValid) return View(color);

            db. Colors.Add(color);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var color = db.Colors.Find(Id);

            if (color == null) return HttpNotFound("Color is not found");

            return View(color);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Color color)
        {
            if (!ModelState.IsValid) return View(color);

            Color colorDb = db.Colors.Find(color.Id);

            colorDb.Name = color.Name;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var color = db.Colors.Find(Id);

            if (color == null) return HttpNotFound("Color is not found");

            return View(color);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteCategory(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var colorDb = db.Colors.Find(Id);

            if (colorDb == null) return HttpNotFound("Color is not found");

            db.Colors.Remove(colorDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}