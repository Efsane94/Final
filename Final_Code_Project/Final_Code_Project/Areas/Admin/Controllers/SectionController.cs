using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.DAL;
using Final_Code_Project.Extensions;
using Final_Code_Project.Models;
using static Final_Code_Project.Utilities.Utilities;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class SectionController : Controller
    {
        private readonly E_ShopContext db;

        public SectionController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/Section
        public ActionResult Index()
        {
            return View(db.Sections.ToList());
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            Section section = db.Sections.Where(s => s.Id == Id).FirstOrDefault();

            if (section == null)
                return HttpNotFound("Section is not found");

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Photo")] Section section)
        {
            if (!ModelState.IsValid) return View(section);

            Section sectionDb =db.Sections.Find(section.Id);

            if (section.Photo != null)
            {
                if (!section.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo is not valid");
                    return View(section);
                }
                RemoveImage(sectionDb.Image, "~/Assets/img/");
                sectionDb.Image = section.Photo.SaveImage("e-commerce", "~/Assets/img");
            }

            sectionDb.Name = section.Name;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}