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
    public class MainHeaderController : Controller
    {
        private readonly E_ShopContext db;

        public MainHeaderController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/MainHeader
        public ActionResult Index()
        {
            return View(db.MainHeader.First());
        }

        public ActionResult Edit()
        {
            return View(db.MainHeader.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Photo")] MainHeader header)
        {
            MainHeader headerDb = db.MainHeader.First();
            if (header.Photo != null)
            {
                if (!header.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo is not valid");
                    return View(header);
                }
                RemoveImage(headerDb.Image, "~/Assets/img");
                headerDb.Image = header.Photo.SaveImage("e-commerce", "~/Assets/img");
            }

            headerDb.Title = header.Title;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}