using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEMIS.Data;
using TEMIS.Models;

namespace TEMIS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private TEMISContext db = new TEMISContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var usuarioDB = from u in db.Usuario select u;

             var usuario = usuarioDB.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                // Si el usuario existe, compara la contraseña
                if (usuario.PasswordHash == password)
                {
                    // Si la contraseña coincide, establece la sesión y redirige al usuario
                    Session["start"] = "ok";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Si la contraseña es incorrecta, mostrar un mensaje de error o realizar otra acción
                    ViewBag.ErrorMessage = "Contraseña incorrecta. Por favor, intenta de nuevo.";
                    return View("Index");
                }
            }
            else
            {
                // Si el usuario no existe, mostrar un mensaje de error o realizar otra acción
                ViewBag.ErrorMessage = "No se encontró ningún usuario con el email proporcionado.";
                return View("Index");
            }
        }
        public ActionResult Logout()
        {
            Session["start"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}