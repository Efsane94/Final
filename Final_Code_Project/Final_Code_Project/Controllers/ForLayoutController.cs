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
    public class ForLayoutController : Controller
    {
        private readonly E_ShopContext db;

        public ForLayoutController()
        {
            db = new E_ShopContext();
        }
        public PartialViewResult Index()
        {
            Layout_VM vm = new Layout_VM
            {
                Sections = db.Sections.ToList(),
                SectionCategories = db.SectionCategories.ToList()
            };
            return PartialView("HeaderNavbar", vm);
        }
    }
}