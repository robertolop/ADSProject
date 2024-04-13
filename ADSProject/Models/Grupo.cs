using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Grupo
    {
        public int IdGrupo { get; set; }
        
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La logitud del campo no puede ser mayor a 50 caracteres.")]
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La logitud del campo no puede ser mayor a 50 caracteres.")]
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La logitud del campo no puede ser mayor a 50 caracteres.")]
        public int Ciclo { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La logitud del campo no puede ser mayor a 50 caracteres.")]
        public int Anio { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La logitud del campo no puede ser mayor a 50 caracteres.")]
        public int Anio2 { get; set; }

    }
}
