using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Logica.Models
{
    class LogicaPaquete
    {
        public Paquete AgregarPaquete(Paquete p)
        {
            TurismoAEGLContext Contexto = new TurismoAEGLContext();
            Paquete paquete = new Paquete();

            paquete = p;

        }
    }
}
