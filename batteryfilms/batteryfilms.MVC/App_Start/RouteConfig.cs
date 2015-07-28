using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace batteryfilms.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(null,
                            "Main",
                            new { controller = "Start", action = "MainPage", CurrentPage = "Main" }
                            );

            routes.MapRoute(null,
                            "Contacts",
                            new { Controller = "Contacts", action = "Contacts", CurrentPage = "Contacts" }
                            );

            routes.MapRoute(null,
                            "Price",
                            new { Controller = "Price", action = "Price", CurrentPage = "Price" }
                            );

            routes.MapRoute(null,
                            "Gallery",
                            new { Controller = "Gallery", action = "List", CurrentPage = "Gallery", category = "ALL", page = 1 }
                            );

            routes.MapRoute(null,
                            "Gallery/Page{page}",
                            new { Controller = "Gallery", action = "List", category = (string)null},
                            new {page = @"\d+"}
                            );


            routes.MapRoute(null,
                            "Gallery/{category}",
                            defaults: new { Controller = "Gallery", action = "List", page = 1 }
                            );

            routes.MapRoute(null,
                            "Gallery/{category}/Page{page}",
                            new { Controller = "Gallery", action = "List" },
                            new { page = @"\d+"}
                            );
            routes.MapRoute(null,
                           "Admin/ClipEditor",
                            new { Controller = "Admin", action = "ClipEditor", CurrentEditor = "ClipEditor" }
                           );
            routes.MapRoute(null,
                           "Admin",
                            new { Controller = "Admin", action = "ClipEditor", CurrentEditor = "ClipEditor" }
                           );
            routes.MapRoute(null,
                            "Admin/FotoEditor",
                            new { Controller = "Admin", action = "FotoEditor", CurrentEditor = "FotoEditor" }
                           );
            routes.MapRoute(null,
                            "Admin/PromoEditor",
                            new { Controller = "Admin", action = "PromoEditor", CurrentEditor = "PromoEditor" }
                           );
            routes.MapRoute(null,
                            "Admin/ArticleEditor",
                            new { Controller = "Admin", action = "ArticleEditor", CurrentEditor = "ArticleEditor" }
                           );


            routes.MapRoute(null,
                            "{controller}/{action}/{id}",
                            new { controller = "Start", action = "MainPage", id = UrlParameter.Optional }
                            );

       }
    }
}