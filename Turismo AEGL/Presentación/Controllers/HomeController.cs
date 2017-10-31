using System.Web.Mvc;
using Presentación.ViewModels;
using System.Collections.Generic;
using Dal;
using Logica.Models;
using Modelo.ViewModels;

namespace Presentación.Controllers
{
    public class HomeController : Controller
    {
        private LogicaHome Logica = new LogicaHome();

        public ActionResult Index()
        {
            List<IndexViewModel> ListaDePaquetes = new List<IndexViewModel>();
            ListaDePaquetes = Logica.ListarTodosLosPaquetesDestacados();
            return View(ListaDePaquetes);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            Usuario usuario;

            if (ModelState.IsValid)
            {
                usuario = Logica.TraerUsuario(model.Email, model.Contrasenia);

                if (usuario != null)
                {
                    Session["IdUsuario"] = usuario.Id;
                    Session["NombreUsuario"] = usuario.Nombre;
                    Session["Email"] = usuario.Email;
                    Session["EsAdmin"] = (usuario.Admin) ? true : false;

                    return RedirectToAction("Index");
                }
            }

            ViewBag.ErrorMessage = "El e-mail o la contraseña son incorrectos.";
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}