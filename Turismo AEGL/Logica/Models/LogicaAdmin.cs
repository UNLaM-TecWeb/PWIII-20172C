using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class LogicaAdmin
    {
        public static List<PaqueteE> ListarPaquetes()
        {

            using (var db = new TurismoAEGLContext())
            {
                var data = from p in db.Paquete
                           select new PaqueteE()
                           {
                               Id = p.Id,
                               Nombre = p.Nombre,
                               Descripcion = p.Descripcion,
                               Foto = p.Foto,
                               FechaInicio = p.FechaInicio,
                               FechaFin = p.FechaFin,
                               LugaresDisponibles = p.LugaresDisponibles,
                               PrecioPorPersona = p.PrecioPorPersona,
                               Destacado = p.Destacado

                           };
                List<PaqueteE> paquetes = data.ToList();
                //List<Paquete> paquetes = db.Paquete.ToList();
                return paquetes;
            }

        }

    }
}
