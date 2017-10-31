using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica.Models;
using System.Diagnostics;
using System.Data.Entity.Validation;

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
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(Paquete p)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                LogicaPaquete.AgregarPaquete(p);
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("Admin/PanelAdmin");
        }

        public ActionResult Editar(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new TurismoAEGLContext())
                {
                    Paquete paq = db.Paquete.Find(id);
                    return View(paq);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Paquete p)
        {
            try
            {
                using (var db = new TurismoAEGLContext())
                {
                    Paquete pa = db.Paquete.Find(p.Id);
                    pa.Nombre = p.Nombre;
                    pa.Descripcion = p.Descripcion;
                    pa.Foto = p.Foto;
                    pa.FechaInicio = p.FechaInicio;
                    pa.FechaFin = p.FechaFin;
                    pa.LugaresDisponibles = p.LugaresDisponibles;
                    pa.PrecioPorPersona = p.PrecioPorPersona;
                    pa.Destacado = p.Destacado;
                    
                    db.SaveChanges();

                    
                }
            }
            catch (DbEntityValidationException e)
            {

                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("PanelAdmin", "Admin");
        }
    }
}