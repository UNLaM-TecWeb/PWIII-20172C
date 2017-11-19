using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Logica.Models
{
    public class LogicaPaquete
    {
        public static void AgregarPaquete(PaqueteE pe)
        {
            using (var db = new TurismoAEGLContext())
            {
                Paquete p = new Paquete();
                p.Id = pe.Id;
                p.Nombre = pe.Nombre;
                p.Descripcion = pe.Descripcion;
                p.Foto = pe.Foto;
                p.FechaInicio = pe.FechaInicio;
                p.FechaFin = pe.FechaFin;
                p.LugaresDisponibles = pe.LugaresDisponibles;
                p.PrecioPorPersona = pe.PrecioPorPersona;
                p.Destacado = pe.Destacado;

                db.Paquete.Add(p);
                db.SaveChanges();
            }

        }

        public static void EditarPaquete(PaqueteE p)
        {
            try
            {
                using (var db = new TurismoAEGLContext())
                {
                    Paquete pa = db.Paquete.Find(p.Id);
                    pa.Nombre = p.Nombre;
                    pa.Descripcion = p.Descripcion;
                    if (!p.Foto.Contains(null))
                    {
                        pa.Foto = p.Foto;
                    }
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
        }

        public static List<Paquete> ObtenerPaquete()
        {
            using (var db = new TurismoAEGLContext())
            {
                return db.Paquete.ToList();
            }
        }

        public static void EliminarPaquete(int Id)
        {
            using (var db = new TurismoAEGLContext())
            {
                Paquete paq = db.Paquete.Find(Id);
                List<Reserva> res = db.Reserva.Where(r => r.IdPaquete == Id).ToList();
                foreach(Reserva r in res)
                {
                    db.Reserva.Remove(r);
                }
                
                db.Paquete.Remove(paq);
                db.SaveChanges();
            }
        }


    }
}
