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
        LogicaReserva reserva = new LogicaReserva();

        public ActionResult Listar()
        {
            List<HistorialReservasViewModel> Listado;

            if (Session["IdUsuario"] == null || Convert.ToBoolean(Session["EsAdmin"]))
            {
                return RedirectToAction("Index", "Home");
            }

            Listado = logicaReserva.ListarReservas(Convert.ToInt32(Session["IdUsuario"]));
            return View(Listado);

        }

        [HttpGet]
        public ActionResult Cancelar(int id)
        {
            reserva.EliminarReserva(Convert.ToInt32(id));

            return RedirectToAction("Listar", "Reserva");
        }
    }
}