using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.DAL;
using Final_Code_Project.Models;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        private readonly E_ShopContext db;

        public ContactController()
        {
            db = new E_ShopContext();
        }
        // GET: Admin/Contact
        public ActionResult Index()
        {
            return View(db.Contact.First());
        }

        public ActionResult Edit()
        {
           
            return View(db.Contact.First());
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Information,Address,Number,Map")] Contact contact)
        {
            Contact contactDb = db.Contact.First();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All information should be included");
                return View(contact);
            }

            contactDb.Title = contact.Title;
            contactDb.Address = contact.Address;
            contactDb.Number = contact.Number;
            contactDb.Map = contact.Map;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}