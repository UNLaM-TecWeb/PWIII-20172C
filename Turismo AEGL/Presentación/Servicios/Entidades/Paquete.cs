using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentación.Servicios.Entidades
{
    public class Paquete
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool EsDestacado { get; set; }
        public int LugaresDisponibles { get; set; }
        public int PrecioPorPersona { get; set; }
    }
}