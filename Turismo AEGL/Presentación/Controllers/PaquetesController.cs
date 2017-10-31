using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentación.Controllers
{
    public class PaquetesController : Controller
    {
        // GET: Paquetes
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Paquete p)
        {
            return View();
        }
    }
}