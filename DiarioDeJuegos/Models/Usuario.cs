using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DiarioDeJuegos.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string ClaveHash { get; set; } = string.Empty;

        public string? ImagenPerfil { get; set; }

        public List<Vivencia> Vivencias { get; set; } = new();
    }
}