using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace batteryfilms.MVC.Controllers
{
    public class AdminMainMenuController : Controller
    {
        public PartialViewResult AdminMainMenu(string CurrentEditor = "ClipEditor")
        {
            ViewBag.CurrentEditor = CurrentEditor;
            return PartialView();
         }
    }
}
