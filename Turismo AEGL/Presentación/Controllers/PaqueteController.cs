using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica.Models;
using Dal;
using Modelo.ViewModels;

namespace Presentación.Controllers
{
    public class PaqueteController : Controller
    {
        LogicaHome Logica = new LogicaHome();
        LogicaReserva logicaReserva = new LogicaReserva();

        public ActionResult Detalle(int id)
        {
            Paquete traerP = Logica.TraerPaquete(id);
            return View(traerP);
        }

        //[HttpPost]
        public ActionResult Reservar(int idPaquete, int idUsuario, int cantP = 1)
        {
            Reserva r = logicaReserva.GenerarReserva(idPaquete, idUsuario, cantP);
            //    Convert.ToInt32(formRes["IdPaquete"]),
            //    Convert.ToInt32(formRes["IdUsuario"]),
            //    Convert.ToInt32(formRes["CantPersonas"])
            //);

            logicaReserva.GuardarReserva(r);
            return RedirectToAction("Listar", "Reserva");
        }
    }
}