using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ECommerceApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AboutRoute",
                url: "a-propos",
                defaults: new { controller = "Home", action = "About" });

            routes.MapRoute(
                name: "ContactRoute",
                url: "nous-contacter",
                defaults: new { controller = "Home", action = "Contact" });

            routes.MapRoute(
                name: "ContactIdRoute",
                url: "contacter/{id}",
                defaults: new { controller = "Home", action = "Contact" },
                constraints: new { id = @"\d+"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                namespaces: new string[] { "ECommerceApp.Controllers" },
                defaults: new { controller = "Produit", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}