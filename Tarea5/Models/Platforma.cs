using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class Plataforma
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    public bool Activa { get; set; }

    public List<Videojuego> Videojuegos { get; set; }
}


// using System.ComponentModel.DataAnnotations;

// public class Plataforma
// {
//     public int Id { get; set; }

//     [Required(ErrorMessage = "El nombre de la plataforma es obligatorio")]
//     [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
//     public string Nombre { get; set; }

//     public bool Activa { get; set; } = true;
// }