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
using System.IO;
using System.Threading.Tasks;



namespace TEMIS.Controllers
{
    public class CasosController : Controller
    {
        private readonly string _uploadFolderPath;

        public CasosController()
        {
            // Configurar la ruta de la carpeta de subidas
            _uploadFolderPath = @"C:\Users\Rolan\Downloads\TEMIS\Documentos";
            if (!Directory.Exists(_uploadFolderPath))
            {
                Directory.CreateDirectory(_uploadFolderPath);
            }
        }

        private TEMISContext db = new TEMISContext();

        // GET: Casos
        public ActionResult Index(string sortOrder, string filtroActual, string cadenaBuscar, int? pagina)
        {
            if ("ok" != Session["start"])
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.CasoNombreSortParam = String.IsNullOrEmpty(sortOrder) ? "apellido_desc" : "";
            ViewBag.OrdenamiendoActual = sortOrder;
            ViewBag.TipoFacturacionSortParam = sortOrder == "fact_asc" ? "fact_desc" : "fact_asc";

            var casos = from s in db.Casos select s;

            if (!string.IsNullOrEmpty(cadenaBuscar))
            {
                casos = casos.Where(s => s.Caso_Nombre.Contains(cadenaBuscar) || s.Tipo_Facturacion.Contains(cadenaBuscar));
            }

            if (cadenaBuscar != null)
            {
                pagina = 1;
            }
            else
            {
                cadenaBuscar = filtroActual;
            }

            ViewBag.FiltroActual = cadenaBuscar;

            switch (sortOrder)
            {
                case "apellido_desc":
                    casos = casos.OrderByDescending(s => s.Caso_Nombre);
                    break;
                case "dui_desc":
                    casos = casos.OrderByDescending(s => s.Tipo_Facturacion);
                    break;
                case "dui_asc":
                    casos = casos.OrderBy(s => s.PrecioCaso);
                    break;
                default:
                    casos = casos.OrderBy(s => s.Caso_Nombre);
                    break;
            }

            int PageSize = 5;
            int PageNumber = (pagina ?? 1);

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

        // Método para manejar la subida de archivos
        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase file, string caseId)
        {
            if (file != null && file.ContentLength > 0)
            {
                string caseFolder = Path.Combine(_uploadFolderPath, caseId.ToString());
                string filePath = Path.Combine(caseFolder, Path.GetFileName(file.FileName));

                if (!Directory.Exists(caseFolder))
                {
                    Directory.CreateDirectory(caseFolder);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.InputStream.CopyToAsync(stream);
                }
            }

            // Obtener la lista de archivos para el caso actual y pasarla a la vista usando ViewBag
            List<string> files = GetFilesForCase(caseId);
            ViewBag.Files = files;

            return RedirectToAction("Details", new { id = caseId });
        }

        private List<string> GetFilesForCase(string caseId)
        {
            var caseFolder = Path.Combine(_uploadFolderPath, caseId.ToString());
            if (Directory.Exists(caseFolder))
            {
                return Directory.GetFiles(caseFolder).Select(Path.GetFileName).ToList();
            }

            return new List<string>();
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
