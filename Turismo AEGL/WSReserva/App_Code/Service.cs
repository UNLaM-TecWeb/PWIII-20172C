using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Logica.Models;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod(EnableSession = true)]
    public void CancelarReserva(int idReserva)
    {
        string Usuario = HttpContext.Current.Session["IdUsuario"].ToString();
        LogicaReserva logicaR = new LogicaReserva();

        if (Usuario != String.Empty &&                                                  // Chequeo que el usuario esté logeado,
            logicaR.ReservaCorrespondeAUsuario(idReserva, Convert.ToInt32(Usuario)) &&  // que la reserva sea del usuario logeado y         
            logicaR.FechaDeInicio(idReserva) > System.DateTime.Now)                     // que la reserva sea posterior a la fecha actual.
        {
            logicaR.EliminarReserva(idReserva);
        }
    }
}