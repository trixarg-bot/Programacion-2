using System;
using System.ComponentModel.DataAnnotations;

public class Videojuego
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El desarrollador es obligatorio")]
    public string Desarrollador { get; set; }

    [Required(ErrorMessage = "La plataforma es obligatoria")]
    public string Plataforma { get; set; }

    [Required(ErrorMessage = "El género es obligatorio")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "La fecha de lanzamiento es obligatoria")]
    public DateTime FechaLanzamiento { get; set; }

    [Required(ErrorMessage = "La URL de la imagen es obligatoria")]
    [Url(ErrorMessage = "Debe ser una URL válida")]
    public string ImagenPortada { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria")]
    [MinLength(10, ErrorMessage = "La descripción debe tener al menos 10 caracteres")]
    public string Descripcion { get; set; }
}