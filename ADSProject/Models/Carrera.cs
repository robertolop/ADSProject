using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La logitud del campo no puede ser mayor 3 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La logitud del campo no puede ser mayor a 40 caracteres.")]
    }
}
