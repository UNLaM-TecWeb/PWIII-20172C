using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class PaqueteE
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no debe superar los 100 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La foto es requerida")]
        public string Foto { get; set; }
        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        [DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
        [Display(Name = "Fecha de inicio")]
        public System.DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha de fin es requerida")]
        [DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
        [Display(Name = "Fecha de fin")]
        public System.DateTime FechaFin { get; set; }
        public bool Destacado { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Solo se aceptan valores positivos")]
        public Nullable<int> LugaresDisponibles { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Solo se aceptan valores positivos")]
        public int PrecioPorPersona { get; set; }

        public string NombreSignificativoImagen
        {
            get
            {
                //en caso de ambos null, devuelve "ApellidoNombre"
                return string.Format("{0}{1}", this.Descripcion ?? "Descripcion", this.Nombre ?? "Nombre");
            }
        }
    }

    

}
