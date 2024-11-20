using System;
using System.ComponentModel.DataAnnotations;

namespace DiarioDeJuegos.Models
{
    public class Vivencia
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public string? ImagenUrl { get; set; }

        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
    }
}