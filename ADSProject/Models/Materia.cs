using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public string NombreMateria { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]
        public string NombreMateria2 { get; set; }
    }
}
