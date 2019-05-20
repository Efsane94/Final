using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.Models;
using Final_Code_Project.Models.ViewModels;
using Final_Code_Project.DAL;
using Microsoft.Ajax.Utilities;

namespace Final_Code_Project.Controllers
{
    public class DetailsController : Controller
    {
        private readonly E_ShopContext db;
        
        public DetailsController()
        {
            db = new E_ShopContext();
        }
        // GET: Details
        public ActionResult Index(int? Id)
        {
            if (Id == null) return HttpNotFound();
            var user = Session["user"] as User;

            var product = db.Products.Find(Id);

            ProductColorSize productColorSize = db.ProductColorSize.Where(p => p.ProductId == Id).FirstOrDefault();

            int sizeId = db.ProductColorSize.Where(p => p.ProductId == Id).FirstOrDefault().SizeId;

            List<Image> productImages = db.Images.Where(s => s.ProductId == Id).ToList();

            List<int> productsSize = db.ProductColorSize.Where(i => i.ProductId == Id).ToList().DistinctBy(x=>x.SizeId).Select(s => s.SizeId).ToList();
            List<int> productsColor = db.ProductColorSize.Where(i => i.ProductId == Id && i.SizeId == sizeId).Select(s => s.ColorId).ToList();

            List<Size> sizes = new List<Size>();
            List<Color> colors = new List<Color>();

            foreach (var item in db.Sizes)
            {
                foreach (var item2 in productsSize)
                {
                    if (item.Id == item2)
                    {
                        sizes.Add(item);
                    }
                }

            }

            foreach (var item in db.Colors)
            {
                foreach (var item2 in productsColor)
                {
                    if (item.Id == item2)
                    {
                        colors.Add(item);
                    }
                }

            }

            if (user == null)
            {
                Details_VM vm = new Details_VM
                {
                    ProductSize = productColorSize,
                    Images = productImages,
                    Sizes = sizes,
                    Colors = colors,
                    Product = product
                };
            }

            Details_VM vm2 = new Details_VM
            {
                ProductSize = productColorSize,
                Images = productImages,
                Sizes=sizes,
                Colors=colors,
                Product=product,
                User=Session["user"] as User,
                Favorites = db.Favorites.ToList()
            };

            return View(vm2);
        }
    }
}