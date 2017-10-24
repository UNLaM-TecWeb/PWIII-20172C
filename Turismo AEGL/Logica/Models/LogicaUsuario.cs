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
            Usuario usuario = new Usuario();

            var usu = (from u in Contexto.Usuario
                       where u.Email == email && u.Contrasenia == contrasenia
                       select u);

            usuario = (usu.Count() > 0) ? usu.First() : null;

            return usuario;
        }
    }
}
