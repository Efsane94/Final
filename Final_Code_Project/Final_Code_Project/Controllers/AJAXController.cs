using Final_Code_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.DAL;
using Final_Code_Project.Models;
using Final_Code_Project.Models.ViewModels;
using System.Threading.Tasks;

namespace Final_Code_Project.Controllers
{
    public class AJAXController : Controller
    {
        // GET: AJAX
        private readonly E_ShopContext db;

        public AJAXController()
        {
            db = new E_ShopContext();
        }
        public ActionResult LoadMoreProducts(int skipCount, int section, int category)
        {
            var sectionCatId = db.SectionCategories.Where(s => s.SectionId == section && s.CategoryId == category).First().Id;

            var productImages = db.Products.Where(s => s.SectionCategoryId == sectionCatId)
                .OrderByDescending(m=>m.Id)
                .Skip(skipCount)
                .Take(8)
                .ToList();
            var user = Session["user"] as User;
            if (user == null)
            {

                Shop_VM vm2 = new Shop_VM
                {
                    Products = productImages
                };
                return PartialView("_loadProducts", vm2);
               
            }
            Shop_VM vm = new Shop_VM
            {
                User = Session["user"] as User,
                Favorites = db.Favorites.ToList(),
                Products = productImages
            };
            return PartialView("_loadProducts", vm);
        }


        public ActionResult loadColor(int? productId, int? sizeId)
        {
            var productSize = db.ProductColorSize.Where(s => s.ProductId == productId && s.SizeId == sizeId).ToList();

            var color = productSize.First().ColorId;
            int amount = db.ProductColorSize.Where(s => s.SizeId == sizeId && s.ColorId == color).First().Amount;

            List<Color> list = new List<Color>();

            foreach (var item in db.Colors)
            {
                foreach (var item2 in productSize)
                {
                    if (item.Id == item2.ColorId)               
                    {
                        
                        list.Add(item);
                    }
                }
            }

            

            Details_VM vm = new Details_VM
            {
                Colors = list,
                Amount=amount
            };

            return PartialView("_loadColors",vm);
        }

        public ActionResult Favourite(int favId)
        {
            var product = db.Products.Where(p => p.Id == favId).First();

            return PartialView("_loadFavs",product);
        }

        public ActionResult AddFavorite(int id) {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return Json(new { status = "404" }, JsonRequestBehavior.AllowGet);
            }
            var user = Session["user"] as User;
            db.Favorites.Add(new Favorite() {
                ProductId = product.Id,
                UserId = user.Id
            });
            db.SaveChanges();
            return Json(new { status = "200" },JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteFavorite(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return Json(new { status = "404" }, JsonRequestBehavior.AllowGet);
            }
            var user = Session["user"] as User;

            var a = db.Favorites.Where(x => x.ProductId == id && x.UserId == user.Id).First();
            db.Favorites.Remove(a);
            db.SaveChanges();
            return Json(new { status = "200" }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Cart() {
            var user = Session["user"] as User;
            Shop_VM shop_VM = new Shop_VM() {
                Favorites = db.Favorites.Where(x=>x.UserId == user.Id).ToList(),
            };
            return PartialView("~/Views/AJAX/Cart.cshtml", shop_VM);
        }


        public async Task<ActionResult> RemoveFavourite(int id)
        {
            var user = Session["user"] as User;

            var favId = db.Favorites.Where(f => f.UserId == user.Id && f.ProductId == id).First();
            db.Favorites.Remove(favId);
            await db.SaveChangesAsync();
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}