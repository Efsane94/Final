using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.DAL;
using Final_Code_Project.Models;
using Final_Code_Project.Models.ViewModels;

namespace Final_Code_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly E_ShopContext db;
        public HomeController()
        {
            db = new E_ShopContext();
        }

        public ActionResult Index()
        {
            
            HomeIndex_VM vm = new HomeIndex_VM()
            {
                MainHeader = db.MainHeader.First(),
                Sections=db.Sections.ToList(),
                GlobalSale=db.GlobalSales.First()
            };
            return View(vm);
        }

        
    }
}