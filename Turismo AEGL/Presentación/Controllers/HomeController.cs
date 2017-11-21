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

        [HttpGet]
        public ActionResult Login(string con, string act, string Idp)
        {
            ViewBag.Con = con;
            ViewBag.Act = act;
            ViewBag.Idp = Idp;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            Usuario usuario;

            if (model.Idp == 0)
                ModelState["Idp"].Errors.Clear();

            if (ModelState.IsValid)
            {
                usuario = Logica.TraerUsuario(model.Email, model.Contrasenia);

                if (usuario != null)
                {
                    Session["IdUsuario"] = usuario.Id;
                    Session["NombreUsuario"] = usuario.Nombre;
                    Session["Email"] = usuario.Email;
                    Session["EsAdmin"] = (usuario.Admin) ? true : false;

                   if (model.Act != null && model.Con != null)
                    {
                        if(model.Idp != 0)
                        {
                            return RedirectToAction(model.Act, model.Con, new { id = model.Idp });
                        }
                        return RedirectToAction(model.Act, model.Con);
                    }
                    else
                        return RedirectToAction("Index", "Home");
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