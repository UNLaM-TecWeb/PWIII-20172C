using System.Collections.Generic;
using System.Linq;
using Dal;
using System;
using Modelo.ViewModels;

namespace Logica.Models
{
    public class LogicaReservaListarViewModel
    {
        TurismoAEGLContext Contexto = new TurismoAEGLContext();

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
