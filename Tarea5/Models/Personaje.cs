using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class Personaje
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    public string Alias { get; set; }

    [Required]
    public string RolEnJuego { get; set; }

    public string HabilidadEspecial { get; set; }

    public string ArmaFavorita { get; set; }

    [Range(1, 100)]
    public int NivelDePoder { get; set; }

    public string ImagenUrl { get; set; }

    public int VideojuegoId { get; set; }
    public Videojuego Videojuego { get; set; }
}

// using System.ComponentModel.DataAnnotations;

// public class Personaje
// {
//     public int Id { get; set; }

//     [Required(ErrorMessage = "El nombre es obligatorio")]
//     [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
//     public string Nombre { get; set; }

//     [StringLength(100, ErrorMessage = "El alias no puede tener más de 100 caracteres")]
//     public string Alias { get; set; }

//     [Required(ErrorMessage = "El rol en el juego es obligatorio")]
//     [StringLength(50, ErrorMessage = "El rol no puede tener más de 50 caracteres")]
//     public string RolEnJuego { get; set; }

//     [StringLength(200, ErrorMessage = "La habilidad especial no puede tener más de 200 caracteres")]
//     public string HabilidadEspecial { get; set; }

//     [StringLength(100, ErrorMessage = "El arma favorita no puede tener más de 100 caracteres")]
//     public string ArmaFavorita { get; set; }

//     [Range(1, 100, ErrorMessage = "El nivel de poder debe estar entre 1 y 100")]
//     public int NivelDePoder { get; set; }

//     [Required(ErrorMessage = "La URL de la imagen es obligatoria")]
//     [Url(ErrorMessage = "Debe ser una URL válida")]
//     public string ImagenUrl { get; set; }
// }