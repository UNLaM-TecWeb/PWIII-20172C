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
                
                using (var db = new TurismoAEGLContext())
                {
                
                    List<Paquete> paquetes = db.Paquete.ToList();
                    return View(paquetes);
                }
        }
    }
}