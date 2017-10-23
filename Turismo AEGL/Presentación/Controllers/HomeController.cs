using Presentación.Servicios;
using Presentación.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentación.ViewModels;
using Dal;
using Logica.Models;

namespace Presentación.Controllers
{
    public class HomeController : Controller
    {
        private LogicaUsuario Logica = new LogicaUsuario();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                TurismoAEGLContext Contexto = new TurismoAEGLContext();
                var Usuario = Logica.TraerUsuario(model.Email, model.Contrasenia);

                if (Usuario != null)
                {
                    Session["IdUsuario"] = Usuario.Id;
                    Session["NombreUsuario"] = Usuario.Nombre;
                    Session["Email"] = Usuario.Email;
                    Session["EsAdmin"] = (Usuario.Admin) ? true : false;

                    return RedirectToAction("Index");
                }
            }
            return View("Usuario o Contraseña incorrectos.");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}