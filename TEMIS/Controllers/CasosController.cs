using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TEMIS.Data;
using TEMIS.Models;


namespace TEMIS.Controllers
{
    public class CasosController : Controller
    {
        private TEMISContext db = new TEMISContext();

        // GET: Casos
        public ActionResult Index()
        {
            return View(db.Casos.ToList());
        }

        // GET: Casos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casos casos = db.Casos.Find(id);
            if (casos == null)
            {
                return HttpNotFound();
            }
            return View(casos);
        }

        // GET: Casos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Casos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Case,Caso_Nombre,Tipo_Facturacion,PrecioCaso")] Casos casos)
        {
            if (ModelState.IsValid)
            {
                db.Casos.Add(casos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(casos);
        }

        // GET: Casos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casos casos = db.Casos.Find(id);
            if (casos == null)
            {
                return HttpNotFound();
            }
            return View(casos);
        }

        // POST: Casos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Case,Caso_Nombre,Tipo_Facturacion,PrecioCaso")] Casos casos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(casos);
        }

        // GET: Casos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casos casos = db.Casos.Find(id);
            if (casos == null)
            {
                return HttpNotFound();
            }
            return View(casos);
        }

        // POST: Casos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Casos casos = db.Casos.Find(id);
            db.Casos.Remove(casos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
