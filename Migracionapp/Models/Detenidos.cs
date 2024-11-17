using System;
using System.ComponentModel.DataAnnotations;


namespace Migracionapp.Models
{
    public class Detenido
    {
        public int Id {get; set;}

        public DateTime FechaDetencion {get; set;}

        public string NombreCompleto {get; set;}

        public string NumeroPasaporte {get; set;}

        public DateTime FechaNacimiento {get; set;}

        public double Latitud {get; set;}

        public double Longitud {get; set;}
    }
}