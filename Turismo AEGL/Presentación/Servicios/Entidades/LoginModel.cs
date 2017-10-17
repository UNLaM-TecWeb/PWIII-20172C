using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentación.Servicios.Entidades
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public LoginModel()
        {
            Email = "";
            Contrasenia = "";
        }
    }
}