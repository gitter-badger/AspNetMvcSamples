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
    public class CategorieController : Controller
    {
        private ECommerceAppDbEntities db = new ECommerceAppDbEntities();

        //
        // GET: /Categorie/

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        //
        // GET: /Categorie/Details/5

        public ActionResult Details(int id = 0)
        {
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        //
        // GET: /Categorie/Create
        [Authorize(Roles=RoleNames.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categorie/Create

        [HttpPost]
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Create(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorie);
        }

        //
        // GET: /Categorie/Edit/5

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Edit(int id = 0)
        {
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        //
        // POST: /Categorie/Edit/5

        [HttpPost]
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Edit(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        //
        // GET: /Categorie/Delete/5

        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Delete(int id = 0)
        {
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        //
        // POST: /Categorie/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorie categorie = db.Categories.Find(id);
            db.Categories.Remove(categorie);
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