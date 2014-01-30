using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule2.Models;

namespace TPModule2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modifiez ce modèle pour dynamiser votre application ASP.NET MVC.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Votre page de description d’application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Votre page de contact.";

            return View();
        }

        public ActionResult Form()
        {
            ViewBag.SelectListType = new SelectList(LoadSearchType(), "TypeId", "TypeName");
            ViewBag.List = new List<string> { "plop", "plip", "toto", "titi" };
            return View();
        }

        public ActionResult Result(int id, string name, int type)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.Type = type;
            return View();
        }

        [HttpPost]
        public ActionResult AjaxSearch(string q)
        {
            //throw new Exception("pouet");
            return Content("Quelques résultats :<br /> 1 résultat");
        }

        public ActionResult AjaxTest()
        {
            return View();
        }

        private System.Collections.IEnumerable LoadSearchType()
        {
            return new List<SearchType> { new SearchType { TypeId = 1, TypeName = "plop" }, new SearchType { TypeId = 2, TypeName = "titi" } };
        }
    }
}
