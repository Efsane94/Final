using Final_Code_Project.DAL;
using Final_Code_Project.Extensions;
using static Final_Code_Project.Utilities.Utilities;
using Final_Code_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class GlobalSaleController : Controller
    {
        private readonly E_ShopContext db;

        public GlobalSaleController ()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/MainHeader
        public ActionResult Index()
        {
            return View(db.GlobalSales.First());
        }

        public ActionResult Edit()
        {
            return View(db.GlobalSales.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Photo")] GlobalSale sale)
        {
            GlobalSale saleDb = db.GlobalSales.First();
            if (sale.Photo != null)
            {
                if (!sale.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo is not valid");
                    return View(sale);
                }
                RemoveImage(saleDb.Image, "~/Assets/img");
                saleDb.Image = sale.Photo.SaveImage("e-commerce", "~/Assets/img");
            }
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}