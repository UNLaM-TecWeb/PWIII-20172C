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
    }
}
