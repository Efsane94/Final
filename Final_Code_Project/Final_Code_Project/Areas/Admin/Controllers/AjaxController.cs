using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.Models;
using Final_Code_Project.DAL;

namespace Final_Code_Project.Areas.Admin.Controllers
{
   

    public class AjaxController : Controller
    {
        private readonly E_ShopContext db;

        public AjaxController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/Ajax
        public ActionResult GetCategories(int id)
        {
            return Json(db.SectionCategories.Where(s => s.Section.Id == id).Select(s => new
            {
                s.Category.Id,
                s.Category.Name
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadSizes(int id)
        {
            var dbprod = db.Products.Find(id);
            var pivotsec = db.SectionCategories.Where(m => m.Id == dbprod.SectionCategoryId).Single();
            var category = db.Categories.Find(pivotsec.CategoryId);
            var section = db.Sections.Find(pivotsec.SectionId);
            var sizes = db.CategorySizes.Where(m => m.SectionId == section.Id && m.CategoryId == category.Id).Select(m => new { Id = m.Size.Id, Name = m.Size.Name }).ToList();
            List<Size> size = new List<Size>();
            foreach (var item in sizes)
            {
                size.Add(new Size { Id = item.Id, Name = item.Name });
            }


                return PartialView("_loadsizes", size);
        }

    }
}