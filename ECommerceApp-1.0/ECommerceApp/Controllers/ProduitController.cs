using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceApp.Models;

namespace ECommerceApp.Controllers
{
    public class ProduitController : Controller
    {
        private ECommerceAppDbEntities db = new ECommerceAppDbEntities();

        //
        // GET: /Produit/

        public ActionResult Index(int? id)
        {
            var produits = db.Produits.Include(p => p.Categorie);

            if (id.HasValue)
            {
                produits = produits.Where(p => p.IdCategorie == id);
                ViewBag.CategoryName = db.Categories.Find(id).Nom;
            }

            return View(produits.ToList());
        }

        //
        // GET: /Produit/Details/5

        public ActionResult Details(int id = 0)
        {
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}