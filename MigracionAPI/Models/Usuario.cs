using System.ComponentModel.DataAnnotations;

namespace MigracionAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Clave { get; set; }

        public virtual ICollection<Incidencia> Incidencias { get; set; }
    }
}