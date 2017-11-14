using System.ComponentModel.DataAnnotations;

namespace Presentación.ViewModels
{
    public class LoginViewModel
    {
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El email es invalido")]
        [Required (ErrorMessage = "Éste campo es requerido.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Éste campo es requerido.")]
        public string Contrasenia { get; set; }

        public string Con { get; set; }
        public string Act { get; set; }
        //public int Idp { get; set; }
    }
}