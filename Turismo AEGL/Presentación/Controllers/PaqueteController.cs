using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica.Models;
using System.Diagnostics;
using System.Data.Entity.Validation;
using Dal;
using System;
using Presentación.Utilities;

namespace Presentación.Controllers
{
    public class PaqueteController : Controller
    {

        // GET: Paquetes
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(PaqueteE p)
        {
            if (ModelState.IsValid)
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
                return RedirectToAction("PanelAdmin", "Admin");
            }
            catch (Exception e)
            {

                throw e;
            }


            
        }

        public ActionResult Editar(int id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(PaqueteE p)
        {
            Paquete paqueteBD = LogicaPaquete.ObtenerPaquete().FirstOrDefault(pa => pa.Id == p.Id);

            if (ModelState.IsValid)
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
                    paqueteBD.Foto = pathRelativoImagen;
                }
            }

            LogicaPaquete.EditarPaquete(p);
            
            return RedirectToAction("PanelAdmin", "Admin");
        }

        public ActionResult Eliminar(int id)
        {
            using (var db = new TurismoAEGLContext())
            {
                Paquete paq = db.Paquete.Find(id);
                return View(paq);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Paquete p)
        {
            
                LogicaPaquete.EliminarPaquete(p.Id);
                
                return RedirectToAction("PanelAdmin", "Admin");
        }
    }
}