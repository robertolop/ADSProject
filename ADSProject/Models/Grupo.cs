using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdGrupo))]
    public class Grupo
    {
        public int IdGrupo { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MinLength(length: 2, ErrorMessage = "La logitud del campo no puede ser menor a 12 caracteres.")]
        [MaxLength(length: 2, ErrorMessage = "La logitud del campo no puede ser mayor a 12 caracteres.")]
        public int Ciclo { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MinLength(length: 4, ErrorMessage = "La logitud del campo no puede ser menor a 12 caracteres.")]
        [MaxLength(length: 4, ErrorMessage = "La logitud del campo no puede ser mayor a 12 caracteres.")]
        public int Anio { get; set; }

    }
}
