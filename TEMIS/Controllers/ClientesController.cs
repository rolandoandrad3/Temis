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
using PagedList;

namespace TEMIS.Controllers
{
    public class ClientesController : Controller
    {
        private TEMISContext db = new TEMISContext();

        // GET: Clientes
        public ActionResult Index(string sortOrder, string filtroActual, string cadenaBuscar, int? pagina)
        {
            if ("ok" != Session["start"])
            {
                return RedirectToAction("Index", "Login");
            }
            // parámetro de ordenamiento en el campo "Apellidos"
            // y lo enviamos a la vista
            ViewBag.ApellidoSortParam = String.IsNullOrEmpty(sortOrder) ? "apellido_desc" : "";

            //Enviar parametro "sortOrder" a la vista 
            ViewBag.OrdenamiendoActual = sortOrder;

            // parámetro de ordenamiento en el campo "DUI"
            // y lo enviamos a la vista
            ViewBag.DUISortParam = sortOrder == "dui_asc" ? "dui_desc" : "dui_asc";
            // variable para el listado de todos los clientes
            // usando LINQ
            var clientes = from s in db.Clientes select s;


            //Definir la busqueda
            if (!string.IsNullOrEmpty(cadenaBuscar))
            {
                //asignar al listado clientes el resultado de la consulta
                clientes = clientes.Where(s => s.PrimNombre.Contains(cadenaBuscar) || s.PrimAprellido.Contains(cadenaBuscar) || s.DUI.Contains(cadenaBuscar));
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
                // ordenamiento descendente por "Apellidos"
                case "apellido_desc":
                    clientes = clientes.OrderByDescending(s => s.PrimAprellido);
                    break;

                // ordenamiento descendente por "DUI"
                case "dui_desc":
                    clientes = clientes.OrderByDescending(s => s.DUI);
                    break;

                // ordenamiento ascendente por "DUI"
                case "dui_asc":
                    clientes = clientes.OrderBy(s => s.DUI);
                    break;

                // ordenamiento ascendente por "Apellidos"
                default:
                    clientes = clientes.OrderBy(s => s.PrimAprellido);
                    break;
            }
            //definir el tamaño de la pagina y la cantidad de paginas
            int PageSize = 5;
            int PageNumber = (pagina ?? 1);

            //return View(db.Clientes.ToList());
            //return View(clientes.ToList()); Ya no se puede usar este return
            return View(clientes.ToPagedList(PageNumber, PageSize));
        }

        // GET: Clientes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cliente,PrimNombre,SegNombre,PrimAprellido,SegAprellido,DUI,Client_Edad,Nacionalidad,Ocupacion,Direccion,Telefonoo,Email")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                try { db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                catch (Exception ex) { ModelState.AddModelError("", "No se pudo guardar los cambios." + ex.Message);}
                
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cliente,PrimNombre,SegNombre,PrimAprellido,SegAprellido,DUI,Client_Edad,Nacionalidad,Ocupacion,Direccion,Telefonoo,Email")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
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
