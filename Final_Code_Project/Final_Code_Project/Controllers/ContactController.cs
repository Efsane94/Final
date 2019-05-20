using Final_Code_Project.DAL;
using Final_Code_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Code_Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly E_ShopContext db;

        public ContactController()
        {
            db = new E_ShopContext();
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View(db.Contact.First());
        }
    }
}