using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentación.Servicios.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public int CantPersonas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CodPaquete { get; set; }
        public int CodUsuario { get; set; }
    }
}