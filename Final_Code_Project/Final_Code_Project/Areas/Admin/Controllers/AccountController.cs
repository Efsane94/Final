using Final_Code_Project.Areas.Admin.Models;
using Final_Code_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Final_Code_Project.Models;
using Final_Code_Project.Extensions;
using static Final_Code_Project.Utilities.Utilities;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        private readonly E_ShopContext db;

        public AccountController()
        {
            db = new E_ShopContext();
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ForAdminLogin admin)
        {
            if (!ModelState.IsValid)
            {
                return View(admin);
            }
            var adminDb = db.Admin.First();
            if (adminDb == null)
            {
                ModelState.AddModelError("Email", "Email is uncorrect!");
                return View(admin);
            }
            var downAdmin = adminDb as _Admin;
            if (!Crypto.VerifyHashedPassword(downAdmin.Password, admin.Password))
            {
                ModelState.AddModelError("AllError", "Email or Password is not valid!");
                return View(admin);
            }

          
            Session["admin"] = downAdmin;
            //var currentadmin = Session["admin"] as _Admin;

            return RedirectToAction("Index", "MainHeader");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Edit()
        {
            return View(db.Admin.First());
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,Password,NewPassword,Image")] _Admin admin,HttpPostedFileBase photo)
        {
 
            var adminDb = db.Admin.Find(admin.Id);
            if (photo != null)
            {
                if (!photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo is not valid");
                    return View(admin);
                }
                //RemoveImage(adminDb.Image, "~/Assets/img");
                adminDb.Image = photo.SaveImage("e-commerce", "~/Assets/img");
            }
            if (admin.NewPassword != null)
            {
                adminDb.Password = Crypto.HashPassword(admin.NewPassword);
            }

            await db.SaveChangesAsync();
            return RedirectToAction("Index","MainHeader");        
     
        }


    }
}