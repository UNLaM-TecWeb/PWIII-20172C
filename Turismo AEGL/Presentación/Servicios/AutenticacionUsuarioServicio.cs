using Presentación.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentación.Servicios
{
    public class AutenticacionUsuarioServicio
    {
        public Usuario Autenticar(string usuario, string password)
        {
            if (usuario == "administrador")
                return new Usuario { EsAdmin = true };

            return new Usuario { EsAdmin = false };

        }
    }
}