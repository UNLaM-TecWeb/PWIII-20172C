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

        public Paquete TraerPaquete(int id)
        {
            Paquete detalle = (
                from p in Contexto.Paquete
                where p.Id == id
                select p).First();

            return detalle;
        }

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
            List<Paquete> ListadoDePaquetesDestacados = TraerPaquetesDestacados();
            List<IndexViewModel> PaquetesDestacados = TransformarPaqueteAIndexViewModel(ListadoDePaquetesDestacados);
            return PaquetesDestacados;
        }

        private List<Paquete> TraerPaquetesDestacados()
        {
            List<Paquete> Paquetes = (
                from p in Contexto.Paquete
                where p.Destacado && p.FechaInicio > DateTime.Today
                orderby p.FechaInicio ascending
                select p).ToList();

            return Paquetes;
        }

        private List<IndexViewModel> TransformarPaqueteAIndexViewModel(List<Paquete> listado)
        {
            IndexViewModel p;
            List<IndexViewModel> Listado = new List<IndexViewModel>();

            foreach (var paquete in listado)
            {
                p = new IndexViewModel();
                p.Id = paquete.Id;
                p.Nombre = paquete.Nombre;
                p.Precio = paquete.PrecioPorPersona;
                p.FechaDeSalida = paquete.FechaInicio.ToLongDateString();
                p.Foto = paquete.Foto;
                Listado.Add(p);
            }

            return Listado;
        }

    }
}
