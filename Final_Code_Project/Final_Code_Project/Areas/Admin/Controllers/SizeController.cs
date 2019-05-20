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
    public class SizeController : Controller
    {
        private readonly E_ShopContext db;

        public SizeController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/Size
        public ActionResult Index()
        {
            return View(db.Sizes.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] Size size)
        {
            if (!ModelState.IsValid) return View(size);

            db.Sizes.Add(size);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var size = db.Sizes.Find(Id);

            if (size == null) return HttpNotFound("Size is not found");

            return View(size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Size size)
        {
            if (!ModelState.IsValid) return View(size);

            Size sizeDb = db.Sizes.Find(size.Id);

            sizeDb.Name = size.Name;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var size = db.Sizes.Find(Id);

            if (size == null) return HttpNotFound("Size is not found");

            return View(size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteCategory(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var sizeDb = db.Sizes.Find(Id);

            if (sizeDb == null) return HttpNotFound("Size is not found");

            db.Sizes.Remove(sizeDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}