using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Code_Project.Controllers
{
    public class UserAuthorization:AuthorizeAttribute,IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true))
            {
                return;
            }

            if (HttpContext.Current.Session["user"] == null)
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}