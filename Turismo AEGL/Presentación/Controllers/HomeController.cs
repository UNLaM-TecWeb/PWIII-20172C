using Presentación.Servicios;
using Presentación.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentación.Controllers
{
    public class HomeController : Controller
    {
        private AutenticacionUsuarioServicio _servicio = new AutenticacionUsuarioServicio();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
            // Code goes here !
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _servicio.Autenticar(model.Email, model.Contrasenia);

                if (usuario != null)
                {
                    Session["Id"] = 2;
                    Session["EsAdmin"] = true;
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}