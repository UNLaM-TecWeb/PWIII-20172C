using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Logica.Models
{
    public class LogicaPaquete
    {
        public static void AgregarPaquete(Paquete p)
        {
            using (var db = new TurismoAEGLContext())
            {
                db.Paquete.Add(p);
                db.SaveChanges();
            }

        }


    }
}
