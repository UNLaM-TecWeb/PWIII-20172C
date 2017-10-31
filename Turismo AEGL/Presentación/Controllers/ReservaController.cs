using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo.ViewModels;
using Logica.Models;

namespace Presentación.Controllers
{
    public class ReservaController : Controller
    {
        LogicaReservaListarViewModel logicaReserva = new LogicaReservaListarViewModel();

        public ActionResult Listar()
        {
            List<HistorialReservasViewModel> Listado = new List<HistorialReservasViewModel>();

            if (Session["IdUsuario"] == null || Convert.ToBoolean(Session["EsAdmin"]))
            {
                return RedirectToAction("Index", "Home");
            }

            Listado = logicaReserva.ListarReservas(Convert.ToInt32(Session["IdUsuario"]));
            return View(Listado);

        }
    }
}