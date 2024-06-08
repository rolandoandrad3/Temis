using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TEMIS.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string nombreUsuario, string contraseña)
        {
            // Lógica para autenticar al usuario
            if (nombreUsuario == "admin" && contraseña == "admin123")
            {
                // Autenticación exitosa
                FormsAuthentication.SetAuthCookie(nombreUsuario, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Autenticación fallida
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}