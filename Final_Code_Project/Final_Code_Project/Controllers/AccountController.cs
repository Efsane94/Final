using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Code_Project.Models;
using Final_Code_Project.DAL;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Final_Code_Project.Controllers
{
    public class AccountController : Controller
    {
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
        public ActionResult Login(ForLogin user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var userDb = db.Users.FirstOrDefault(m => m.Email.Trim() == user.Email.Trim());
            if (userDb == null)
            {
                ModelState.AddModelError("Email", "Email is not valid");
                return View(user);
            }
            if (!Crypto.VerifyHashedPassword(userDb.Password, user.Password))
            {
                ModelState.AddModelError("AllError", "Email or Password is not valid!");
                return View(user);
            }

            Session["user"] = userDb;
            User currentuser = Session["user"] as User;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register([Bind(Include = "Name,Surname,Email,Password,ConfirmPassword")] User user)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All information must be filled out ");
                return View(user);
            }

            if (user.ConfirmPassword!=user.Password)
            {
                ModelState.AddModelError("ConfirmPassword", "Password confirmation is not correct");
                return View(user);
            }

            user.Password = Crypto.HashPassword(user.Password);

            db.Users.Add(user);
            await db.SaveChangesAsync();
            Session["user"] = user;
            User currentUser = Session["user"] as User;
            return RedirectToAction("Login", "Account");
        }
    }
}