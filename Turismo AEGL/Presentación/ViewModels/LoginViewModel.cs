using System.ComponentModel.DataAnnotations;

namespace Presentación.ViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Éste campo es requerido.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Éste campo es requerido.")]
        public string Contrasenia { get; set; }
    }
}