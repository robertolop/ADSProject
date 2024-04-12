using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo no puede ser mayor a 3 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo no puede ser mayor a 40 caracteres.")]
        public string Descripcion { get; set; }
    }
}
