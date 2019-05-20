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
using Final_Code_Project.Areas.Admin.Models;
using System.Net;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly E_ShopContext db;

        public ProductController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            //ViewBag.categories = db.Categories.ToList();
            //ViewBag.sections = db.Sections.ToList();
            return View(db.Products.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.sections = db.Sections.ToList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include ="Name,Description,AdditionDate,Price,Photo")]Product product, int? CategoryId,int? SectionId)
        { 
            ViewBag.sections = db.Sections.ToList();

            if (ModelState.IsValid)
            {
                if (product.Photo != null)
                {
                    if (!product.Photo.IsImage())
                    {
                        ModelState.AddModelError("allError", "Photo is not valid");
                        return View(product);
                    }
                   
                    product.Image = product.Photo.SaveImage("e-commerce", "~/Assets/img");
                }

                if (SectionId == null || CategoryId == null )
                {
                    ModelState.AddModelError("allError", "Category or Section Id is not found");
                    return View(product);
                }
                else
                {
                    var sectionCat = db.SectionCategories.Where(id => id.SectionId == SectionId && id.CategoryId == CategoryId).First();
                    if (sectionCat ==null)
                    {
                        ModelState.AddModelError("allError", "Section Category is not found");
                        return View();
                    }

                    product.SectionCategoryId = sectionCat.Id;
                }
                db.Products.Add(product);
                await db.SaveChangesAsync();
            }
            else
            {
                
                return View(product);
            }


            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? Id) 
        {
            if (Id == null) return HttpNotFound();
           
            var product = db.Products.Find(Id);
            EditVM editVM = new EditVM() {
                Categories = db.Categories.ToList(),
                Product = product,
                Sections = db.Sections.ToList()
            };
            if (product == null) return HttpNotFound();

            var query1 = (from item in db.SectionCategories
                         where item.SectionId == product.SectionCategory.SectionId
                         select item.CategoryId).ToList();
            List<Category> categories = new List<Category>();

            foreach (var item in db.Categories)
            {
                if (query1.Any(x => x == item.Id))
                {
                    categories.Add(item);
                }
            }

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.SectionCategory.CategoryId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Name", product.SectionCategory.SectionId);

            return View(editVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include ="Id,Name,Description,AdditionDate,Price,Photo")] Product product,int CategoryId,int SectionId)
        {
            if (!ModelState.IsValid) return View(product);

            var sectionCat = db.SectionCategories.Where(s => s.SectionId == SectionId && s.CategoryId == CategoryId).First();
            if (sectionCat == null)
            {
                ModelState.AddModelError("allError", "Section or Category is not found");
                return View(product);
            }
            Product productDb = db.Products.Find(product.Id);

            productDb.SectionCategoryId = sectionCat.Id;

            if (product.Photo != null)
            {
                if (!product.Photo.IsImage())
                {
                    ModelState.AddModelError("allError", "Photo is not valid");
                    return View(product);
                }
                RemoveImage(productDb.Image, "~/Assets/img");
                productDb.Image = product.Photo.SaveImage("e-commerce", "~/Assets/img");
            }
            productDb.Name = product.Name;
            productDb.Description = product.Description;
            productDb.AdditionDate = product.AdditionDate;
            productDb.Price = product.Price;

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
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
            Product productDb = db.Products.Find(id);

            RemoveImage(productDb.Image, "~/Assets/img");
            db.Products.Remove(productDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}