using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace batteryfilms.MVC.Controllers
{
    public class MainMenuController : Controller
    {
        public PartialViewResult MainMenu(string CurrentPage = "Main")
        {
            ViewBag.CurrentPage = CurrentPage;
            return PartialView();
        }
    }
}
