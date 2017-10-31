using System;

namespace Modelo.ViewModels
{
    public class HistorialReservasViewModel
    {
        public int IdReserva { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CantidadDePersonas { get; set; }
        public float PrecioPorPersona { get; set; }
        public float PrecioTotal { get; set; }
    }
}