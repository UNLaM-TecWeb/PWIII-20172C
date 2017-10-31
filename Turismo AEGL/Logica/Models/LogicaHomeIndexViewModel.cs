using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Modelo.ViewModels;

namespace Logica.Models
{
    public class LogicaHomeIndexViewModel
    {
        TurismoAEGLContext Contexto = new TurismoAEGLContext();

        public List<IndexViewModel> ListarTodos()
        {
            // Declaro las variables y objetos que voy a necesitar.
            IndexViewModel Paquete;
            List<IndexViewModel> Listado = new List<IndexViewModel>();
            string [] mes = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

            /* Traigo los datos que necesito para la vista:
             * id del paquete, 
             * nombre del paquete, 
             * cantidad de noches (se calcula a partir de la diferencia entre la fecha de fin y la fecha de inicio),
             * precio del paquete,
             * día de salida (día expresado como fecha, el número del mes),
             * mes de salida (expresado como enero, febrero, etc...)
             */
            var Consulta = (
                from p in Contexto.Paquete
                orderby p.Destacado descending
                select new
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    CantidadDeNoches = p.FechaFin.DayOfYear - p.FechaInicio.DayOfYear,
                    Precio = p.PrecioPorPersona,
                    DiaDeSalida = p.FechaInicio.Day,
                    MesDeSalida = mes[p.FechaInicio.Month-1]
                }).ToList();

            // Genero una lista con los datos que traje en la consulta anterior.
            foreach (var paquete in Consulta)
            {
                Paquete = new IndexViewModel();
                Paquete.Id = paquete.Id;
                Paquete.Nombre = paquete.Nombre;
                Paquete.CantidadDeNoches = paquete.CantidadDeNoches;
                Paquete.Precio = paquete.Precio;
                Paquete.DiaDeSalida = paquete.DiaDeSalida;
                Paquete.MesDeSalida = paquete.MesDeSalida;
                Listado.Add(Paquete);
            }

            // Fin del metodo, devuelvo el listado que armé.
            return Listado;
        }

    }
}
