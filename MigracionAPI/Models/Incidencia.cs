using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigracionAPI.Models
{
    public class Incidencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Pasaporte { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(20)]
        public string WhatsApp { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public double Latitud { get; set; }

        [Required]
        public double Longitud { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        [Required]
        public int CodigoAgente { get; set; }

        [ForeignKey("CodigoAgente")]
        public virtual Usuario Agente { get; set; }

        [StringLength(50)]
        public string? Nacionalidad { get; set; }

        public string? Observaciones { get; set; }

        [StringLength(20)]
        public string? EstadoCaso { get; set; }
    }
}