using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using batteryfilms.MVC.Infrastructure.Abstract;
using batteryfilms.MVC.Models;

namespace batteryfilms.MVC.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider _authProvider)
        {
            authProvider = _authProvider;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.name, model.password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
