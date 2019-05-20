using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.Models;
using Final_Code_Project.DAL;
using Final_Code_Project.Models.ViewModels;
using System.Threading.Tasks;
using System.Net;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class ProductColorSizeController : Controller
    {
        private readonly E_ShopContext db;

        public ProductColorSizeController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/ProductColorSize
        public ActionResult Index()
        {
            return View(db.ProductColorSize.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.products = db.Products.ToList();
            ViewBag.colors = db.Colors.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include ="ProductId,ColorId,Amount")] ProductColorSize productS, int SizeId)
        {
            ViewBag.products = db.Products.ToList();
            ViewBag.colors = db.Colors.ToList();

            if (ModelState.IsValid)
            {
                if (productS.ProductId == 0)
                {
                    ModelState.AddModelError("allError", "No product selected");
                    return View(productS);
                }

                Product product = db.Products.Find(productS.ProductId);

                if (product == null)
                {
                    ModelState.AddModelError("allError", "Product is not valid");
                    return View(productS);
                }

                if (SizeId == 0)
                {
                    ModelState.AddModelError("allError", "Size must be selected");
                    return View(productS);
                }
                Size size = db.Sizes.Find(SizeId);
                productS.SizeId = size.Id;
                if (size == null)
                {
                    ModelState.AddModelError("allError", "Size is not valid");
                    return View(productS);
                }

                if (productS.ColorId == 0)
                {
                    ModelState.AddModelError("allError", "Color must be selected");
                    return View(productS);
                }
                Color color = db.Colors.Find(productS.ColorId);
                if (size == null)
                {
                    ModelState.AddModelError("allError", "Color is not valid");
                    return View(productS);
                }

                if (productS.Amount == 0)
                {
                    ModelState.AddModelError("allError", "Product amount must be included");
                    return View(productS);
                }

                db.ProductColorSize.Add(productS);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {

            ViewBag.colors = db.Colors.ToList();

            if (Id == null) return HttpNotFound();

            var prod = db.ProductColorSize.Find(Id);

            var product = db.Products.Where(p => p.Id == prod.ProductId).First();

            

            if (prod == null) return HttpNotFound();

            int sCatId = product.SectionCategoryId;

            int section = db.SectionCategories.Where(p => p.Id == sCatId).First().SectionId;
            int category = db.SectionCategories.Where(p => p.Id == sCatId).First().CategoryId;

            List<Size> sizes = new List<Size>();

            var sizeDb = db.CategorySizes.Where(s => s.SectionId == section && s.CategoryId == category).Select(m => new { Id = m.Size.Id, Name = m.Size.Name }).ToList();

            foreach (var item in sizeDb)
            {
                sizes.Add(new Size { Id = item.Id, Name = item.Name });
            }
            
            ProductCS_VM vm = new ProductCS_VM
            {
                Sizes = sizes,
                ProductSize = prod
            };
            ViewBag.SizeId = new SelectList(sizes, "Id", "Name", prod.SizeId);
            ViewBag.ColorId = new SelectList(ViewBag.colors, "Id", "Name", prod.ColorId);
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductCS_VM vM , ProductColorSize productColorSize)
        {
            productColorSize.ProductId = vM.ProductSize.ProductId;
            productColorSize.Amount = vM.ProductSize.Amount;
            ViewBag.colors = db.Colors.ToList();

       
                if (productColorSize.Id == 0)
                {
                    ModelState.AddModelError("allError", "Product Id is not found");
                    return View(vM);
                }

                var productDb = db.ProductColorSize.Find(productColorSize.Id);


                if (productDb == null)
                {
                    ModelState.AddModelError("allError", "Product is not found");
                    return View(vM);
                }

            productColorSize.ProductId = productDb.ProductId;

                if (productColorSize.SizeId == 0 || productColorSize.ColorId == 0)
                {
                    ModelState.AddModelError("allError", "Size id or color id is not found");
                    return View(vM);
                }
                productDb.ProductId = productColorSize.ProductId;
                productDb.SizeId = productColorSize.SizeId;
                productDb.ColorId = productColorSize.ColorId;
                productDb.Amount = productColorSize.Amount;

            
            await db.SaveChangesAsync();
             return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColorSize product = db.ProductColorSize.Find(id);
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
            ProductColorSize productDb = db.ProductColorSize.Find(id);
 
            db.ProductColorSize.Remove(productDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}