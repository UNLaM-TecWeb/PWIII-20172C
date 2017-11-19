using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica.Models;
using System.Diagnostics;
using System.Data.Entity.Validation;
using Dal;
using System;
using Presentación.Utilities;
using System.Collections.Generic;
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

        [HttpGet]
        public ActionResult Reservar(int id)
        {
            if (Convert.ToBoolean(Session["IdUsuario"]))
            {
                ViewBag.IdPaquete = id;
                ViewBag.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);



                return View();
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult Reservar(ReservaViewModel re)
        {
            TurismoAEGLContext db2 = new TurismoAEGLContext();
            Reserva r = logicaReserva.GenerarReserva(re.IdPaquete, re.CPersonas, re.IdUsuario);
            Paquete pp = db2.Paquete.Find(re.IdPaquete);
            if (pp.LugaresDisponibles < re.CPersonas)
            {
                return View("ErrorCantidad");
            }

            logicaReserva.GuardarReserva(r);
            return RedirectToAction("Listar", "Reserva");
        }

        public ActionResult Listar()
        {
            if (Convert.ToBoolean(Session["EsAdmin"]))
            {
                List<PaqueteE> ListaPaquetes = LogicaAdmin.ListarPaquetes();
                return View(ListaPaquetes);
            }

            return RedirectToAction("Login", "Home");
        }

        public ActionResult Nuevo()
        {
            if (Convert.ToBoolean(Session["EsAdmin"]))
            {
                return View();
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(PaqueteE p)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    string nombreSignificativo = p.NombreSignificativoImagen;
                    string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                    p.Foto = pathRelativoImagen;
                }
                LogicaPaquete.AgregarPaquete(p);
                return RedirectToAction("Listar", "Paquete");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult Editar(int id)
        {
            if (Convert.ToBoolean(Session["EsAdmin"]))
            {
                try
                {

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

            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(PaqueteE p)
        {
            Paquete paqueteBD = LogicaPaquete.ObtenerPaquete().FirstOrDefault(pa => pa.Id == p.Id);

            if (!ModelState.IsValid)
                return View();
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                if (!string.IsNullOrEmpty(p.Foto))
                {
                    if (!string.IsNullOrEmpty(paqueteBD.Foto))
                    {
                        ImagenesUtility.Borrar(p.Foto);
                    }

                    //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                    string nombreSignificativo = p.NombreSignificativoImagen;
                    //Guardar Imagen
                    string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                    p.Foto = pathRelativoImagen;
                }
            }
            LogicaPaquete.EditarPaquete(p);
            
            return RedirectToAction("Listar", "Paquete");
        }

        public ActionResult Eliminar(int id)
        {
            if (Convert.ToBoolean(Session["EsAdmin"]))
            {
                using (var db = new TurismoAEGLContext())
                {
                    Paquete paq = db.Paquete.Find(id);
                    return View(paq);
                }
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Paquete p)
        {
            
                LogicaPaquete.EliminarPaquete(p.Id);
                
                return RedirectToAction("Listar", "Paquete");
        }
    }
}