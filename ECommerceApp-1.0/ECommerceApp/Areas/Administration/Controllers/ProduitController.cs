using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceApp.Models;

namespace ECommerceApp.Areas.Administration.Controllers
{
    public class ProduitController : Controller
    {
        private ECommerceAppDbEntities db = new ECommerceAppDbEntities();

        //
        // GET: /Produit/

        public ActionResult Index()
        {
            var produits = db.Produits.Include(p => p.Categorie);
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

        //
        // GET: /Produit/Create

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Create()
        {
            ViewBag.IdCategorie = new SelectList(db.Categories, "Id", "Nom");
            return View();
        }

        //
        // POST: /Produit/Create

        [HttpPost]
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Create(Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Produits.Add(produit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategorie = new SelectList(db.Categories, "Id", "Nom", produit.IdCategorie);
            return View(produit);
        }

        //
        // GET: /Produit/Edit/5

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Edit(int id = 0)
        {
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategorie = new SelectList(db.Categories, "Id", "Nom", produit.IdCategorie);
            return View(produit);
        }

        //
        // POST: /Produit/Edit/5

        [HttpPost]
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Edit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategorie = new SelectList(db.Categories, "Id", "Nom", produit.IdCategorie);
            return View(produit);
        }

        //
        // GET: /Produit/Delete/5

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Delete(int id = 0)
        {
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        //
        // POST: /Produit/Delete/5

        [Authorize(Roles = RoleNames.Admin)]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Produit produit = db.Produits.Find(id);
            db.Produits.Remove(produit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}