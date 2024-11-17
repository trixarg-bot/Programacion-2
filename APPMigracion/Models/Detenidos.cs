using System;
using System.ComponentModel.DataAnnotations;

namespace APPMigracion.Models
{
    public class Detenido
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de detención es obligatoria")]
        public DateTime FechaDetencion { get; set; }

        [Required(ErrorMessage = "El nombre y apellido son obligatorios")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El número de pasaporte es obligatorio")]
        public string NumeroPasaporte { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La latitud es obligatoria")]
        public double Latitud { get; set; }

        [Required(ErrorMessage = "La longitud es obligatoria")]
        public double Longitud { get; set; }
    }
}