using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;
using Logica.Models;

namespace Presentación.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult PanelAdmin()
        {
            List<PaqueteE> ListaPaquetes = LogicaAdmin.ListarPaquetes();
            return View(ListaPaquetes);
                
        }
    }
}