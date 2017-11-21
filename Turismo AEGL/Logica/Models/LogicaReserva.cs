using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Modelo.ViewModels;

namespace Logica.Models
{
    public class LogicaReserva
    {
        TurismoAEGLContext Contexto = new TurismoAEGLContext();

        public Reserva GenerarReserva(int IdPaquete, int CantP, int IdUsu)
        {
            Reserva r = new Reserva();

            r.IdPaquete = IdPaquete;
            r.CantPersonas = CantP;
            r.IdUsuario = IdUsu;
            r.FechaCreacion = System.DateTime.Now;

            return (r);
        }

        public void GuardarReserva(Reserva re)
        {

            Paquete paq = new Paquete();
            paq = Contexto.Paquete.Where(p => p.Id == re.IdPaquete).First();
            var cant = paq.LugaresDisponibles - re.CantPersonas;
            paq.LugaresDisponibles = cant;

            Contexto.Reserva.Add(re);
            Contexto.SaveChanges();

        }

        public List<HistorialReservasViewModel> ListarReservas(int idUsuario)
        {
            List<HistorialReservasViewModel> Historial = new List<HistorialReservasViewModel>();
            HistorialReservasViewModel Elemento;

            var consulta = (
                from r in Contexto.Reserva
                join p in Contexto.Paquete on r.IdPaquete equals p.Id
                join u in Contexto.Usuario on r.IdUsuario equals u.Id
                where r.IdUsuario == idUsuario
                select new
                {
                    IdReserva = r.Id,
                    p.Nombre,
                    p.FechaInicio,
                    p.FechaFin,
                    r.CantPersonas,
                    p.PrecioPorPersona,
                    PrecioTotal = r.CantPersonas * p.PrecioPorPersona
                }
            ).ToList();

            foreach (var reserva in consulta)
            {
                Elemento = new HistorialReservasViewModel();
                Elemento.IdReserva = reserva.IdReserva;
                Elemento.Nombre = reserva.Nombre;
                Elemento.FechaInicio = reserva.FechaInicio;
                Elemento.FechaFin = reserva.FechaFin;
                Elemento.CantidadDePersonas = reserva.CantPersonas;
                Elemento.PrecioPorPersona = reserva.PrecioPorPersona;
                Elemento.PrecioTotal = reserva.PrecioTotal;
                Historial.Add(Elemento);
            }

            return Historial;
        }

        public void EliminarReserva(int idReserva)
        {
            Reserva QueryReserva = Contexto.Reserva.Where(r => r.Id == idReserva).First();
            Paquete QueryPaquete = Contexto.Paquete.Where(p => p.Id == QueryReserva.IdPaquete).First();

            QueryPaquete.LugaresDisponibles += QueryReserva.CantPersonas;
            Contexto.Reserva.Remove(QueryReserva);
            Contexto.SaveChanges();
        }

        public bool ReservaCorrespondeAUsuario(int idR, int idU)
        {
            bool resultado = false;

            Reserva res = Contexto.Reserva.Where(r => r.Id == idR).Where(r2 => r2.IdUsuario == idU).First();

            if (res != null)
            {
                resultado = true;
            }

            return resultado;
        }

        public DateTime FechaDeInicio(int idR)
        {
            Reserva res = Contexto.Reserva.Where(r => r.Id == idR).First();
            Paquete paq = Contexto.Paquete.Where(p => p.Id == res.IdPaquete).First();

            return paq.FechaInicio;
        }
    }
}
