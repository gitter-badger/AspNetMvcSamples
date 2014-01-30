using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceApp.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        private ECommerceAppDbEntities db = new ECommerceAppDbEntities();

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
