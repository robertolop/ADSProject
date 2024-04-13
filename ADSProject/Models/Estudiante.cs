﻿using System.ComponentModel.DataAnnotations;


namespace ADSProject.Models
{
    public class Estudiante
    {
        
        public string NombresEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La logitud del campo no puede ser mayor a 50 caracteres.")]
        public string ApellidosEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 50, ErrorMessage = "La logitud del campo no puede ser mayor a 50 caracteres.")]
        public string CodigoEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MinLength(length: 12, ErrorMessage = "La logitud del campo no puede ser menor a 12 caracteres.")]
        [MaxLength(length: 12, ErrorMessage = "La logitud del campo no puede ser mayor a 12 caracteres.")]
        public string CorreoEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido.")]
        [MaxLength(length: 254, ErrorMessage = "La logitud del campo no puede ser mayor a 254 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato de correo electronico no es correcto.")]
        public int IdEstudiante { get; set; }

    }
}
