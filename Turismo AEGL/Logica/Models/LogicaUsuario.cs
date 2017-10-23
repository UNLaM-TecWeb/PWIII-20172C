using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Logica.Models
{
    public class LogicaUsuario
    {
        public Usuario TraerUsuario(string email, string contrasenia)
        {
            TurismoAEGLContext Contexto = new TurismoAEGLContext();
            Usuario Usu = new Usuario();

            Usu = (from u in Contexto.Usuario
                       where u.Email == email && u.Contrasenia == contrasenia
                       select u).First();
            return Usu;
        }
    }
}
