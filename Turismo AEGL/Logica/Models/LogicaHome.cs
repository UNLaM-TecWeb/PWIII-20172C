using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Modelo.ViewModels;

namespace Logica.Models
{
    public class LogicaHome
    {
        TurismoAEGLContext Contexto = new TurismoAEGLContext();

        public Usuario TraerUsuario(string email, string contrasenia)
        {
            Usuario usuario = new Usuario();

            var usu = (from u in Contexto.Usuario
                       where u.Email == email && u.Contrasenia == contrasenia
                       select u);

            usuario = (usu.Count() > 0) ? usu.First() : null;

            return usuario;
        }

        public List<IndexViewModel> ListarTodosLosPaquetesDestacados()
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
             * mes de salida (expresado como enero, febrero, etc...),
             * el path a la foto del paquete
             * 
             * Las validaciones son:
             * - la​ ​fecha​ ​de​ ​inicio​ ​debe ser​ ​mayor​ ​a​ ​la​ ​fecha​ ​actual​ ​y​
             * - tienen que estar ordenados​ ​por​ ​fecha​ ​de​ ​inicio​ ​ascendentemente.
             */
            var Consulta = (
                from p in Contexto.Paquete
                where p.Destacado && p.FechaInicio > DateTime.Today
                orderby p.FechaInicio ascending
                select new
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    CantidadDeNoches = 5,//p.FechaFin.da - p.FechaInicio.DayOfYear,
                    Precio = p.PrecioPorPersona,
                    DiaDeSalida = p.FechaInicio.Day,
                    MesDeSalida = "enero",//mes[p.FechaInicio.Month - 1],
                    Foto = p.Foto
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
