using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private ECommerceAppDbEntities db = new ECommerceAppDbEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View(db.Categories.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult GetCategoriesList()
        {
            return PartialView("_GetCategoriesListPartial", db.Categories.Select(c => new CategoryInfo { Nom = c.Nom, Id = c.Id, NombreDeProduits = c.Produits.Count }).ToList());
            //context.Categories.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
