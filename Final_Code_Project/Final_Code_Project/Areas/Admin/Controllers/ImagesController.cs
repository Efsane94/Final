using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.Models;
using Final_Code_Project.DAL;
using Final_Code_Project.Extensions;
using static Final_Code_Project.Utilities.Utilities;
using System.Threading.Tasks;
using System.Net;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class ImagesController : Controller
    {
        private readonly E_ShopContext db;

        public ImagesController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/Images
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.products = db.Products.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include ="Photo,ProductId")] Image image)
        {
            ViewBag.products = db.Products.ToList();

            if (image.ProductId == 0)
            {
                ModelState.AddModelError("allError", "Product must be selected");
                return View(image);
            }

            if (ModelState.IsValid)
            {
                if (image.Photo != null)
                {
                    if (!image.Photo.IsImage())
                    {
                        ModelState.AddModelError("allError", "Photo type is not valid");
                        return View(image);
                    }
                    image.ImageSource = image.Photo.SaveImage("e-commerce", "~/Assets/img");
                }

                db.Images.Add(image);
                await db.SaveChangesAsync();
            }
            else
            {
                return View(image);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image product = db.Images.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image productDb = db.Images.Find(id);

            RemoveImage(productDb.ImageSource, "~/Assets/img");
            db.Images.Remove(productDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}