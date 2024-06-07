using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
        public ActionResult Index(string sortOrder, string filtroActual, string cadenaBuscar, int? pagina)
        {
            // parámetro de ordenamiento en el campo "Apellidos"
            // y lo enviamos a la vista
            ViewBag.CasoNombreSortParam = String.IsNullOrEmpty(sortOrder) ? "apellido_desc" : "";

            //Enviar parametro "sortOrder" a la vista 
            ViewBag.OrdenamiendoActual = sortOrder;

            // parámetro de ordenamiento en el campo "facturacion"
            // y lo enviamos a la vista
            ViewBag.TipoFacturacionSortParam = sortOrder == "fact_asc" ? "fact_desc" : "fact_asc";
            // variable para el listado de todos los abogados
            // usando LINQ
            var casos = from s in db.Casos select s;


            //Definir la busqueda
            if (!string.IsNullOrEmpty(cadenaBuscar))
            {
                //asignar al listado abogados el resultado de la consulta
                casos = casos.Where(s => s.Caso_Nombre.Contains(cadenaBuscar) || s.Tipo_Facturacion.Contains(cadenaBuscar));
            }

            //definir la paginacion
            if (cadenaBuscar != null)
            {
                pagina = 1;
            }
            else
            {
                cadenaBuscar = filtroActual;
            }
            //definir otro parametro de busqueda para  enviarlo a la vista
            ViewBag.FiltroActual = cadenaBuscar;

            switch (sortOrder)
            {
                // ordenamiento descendente por "Nombre en el caso"
                case "apellido_desc":
                    casos = casos.OrderByDescending(s => s.Caso_Nombre);
                    break;

                // ordenamiento descendente por "Tipo de Facturacion"
                case "dui_desc":
                    casos = casos.OrderByDescending(s => s.Tipo_Facturacion);
                    break;

                // ordenamiento ascendente por "Precio"
                case "dui_asc":
                    casos = casos.OrderBy(s => s.PrecioCaso);
                    break;

                // ordenamiento ascendente por "Apellidos"
                default:
                    casos = casos.OrderBy(s => s.Caso_Nombre);
                    break;
            }
            //definir el tamaño de la pagina y la cantidad de paginas
            int PageSize = 5;
            int PageNumber = (pagina ?? 1);

            //return View(db.Abogados.ToList());
            //return View(abogados.ToList()); Ya no se puede usar este return
            return View(casos.ToPagedList(PageNumber, PageSize));
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
                try {db.Casos.Add(casos);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                catch (Exception ex) { ModelState.AddModelError("", "No se pudo guardar los cambios." + ex.Message); }
                
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
