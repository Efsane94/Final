using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Code_Project.Areas.Admin.Controllers
{
    public class AdminAuthorization: AuthorizeAttribute, IAuthorizationFilter
    {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                {
                    return;
                }

                if (HttpContext.Current.Session["admin"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Admin/Account/Login");
                }
            }
        
    }
}