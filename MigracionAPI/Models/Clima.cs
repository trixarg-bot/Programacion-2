using System.ComponentModel.DataAnnotations;


namespace MigracionAPI.Models
{

    public class ClimaResponse
    {
        public float Temperatura { get; set; }
        public int Humedad { get; set; }
        public string Descripcion { get; set; }
    }
}