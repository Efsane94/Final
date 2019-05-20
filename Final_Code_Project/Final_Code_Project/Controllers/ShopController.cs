using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.Models;
using Final_Code_Project.Models.ViewModels;
using Final_Code_Project.DAL;

namespace Final_Code_Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly E_ShopContext db;

        public ShopController()
        {
            db = new E_ShopContext();
        }
        // GET: Shop
        public ActionResult Index(int? Id,int? catId)
        {
            if (Id == null) return HttpNotFound();

            if (catId != null)
            {
                var sectCatId = db.SectionCategories.Where(s => s.SectionId == Id && s.CategoryId == catId).First().Id;

                var selectedProducts = db.Products.Where(s => s.SectionCategoryId == sectCatId).OrderByDescending(x=>x.Id).Take(6).ToList();
                ViewBag.productCount = db.Products.Where(s => s.SectionCategoryId == sectCatId).Count();
              
                ViewBag.sectionId = Id;
                ViewBag.categoryId =catId;

                var shopHeader = db.ShopHeader.First();
                Shop_VM vm = new Shop_VM
                {
                    Products = selectedProducts,
                    Favorites = db.Favorites.ToList(),
                    User = Session["user"] as User,
                    ShopHeader = shopHeader
                };
                return View(vm);
            }

            var catSe = db.SectionCategories.Where(s => s.SectionId == Id).First().Id;
            ViewBag.sectionId = Id;
            ViewBag.categoryId = 1;

            var list = db.Products.Where(s => s.SectionCategoryId == catSe).OrderByDescending(x => x.Id).Take(6).ToList();

            Shop_VM vm2 = new Shop_VM
            {
                ShopHeader = db.ShopHeader.First(),
                Favorites = db.Favorites.ToList(),
                User = Session["user"] as User,
                Products = list
            };
            ViewBag.productCount = db.Products.Where(s => s.SectionCategoryId == catSe).Count();
            return View(vm2);
        }
    }
}