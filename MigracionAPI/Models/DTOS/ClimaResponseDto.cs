namespace MigracionAPI.Models.DTOs
{
    public class ClimaResponseDto
    {
        public double Temperatura { get; set; }
        public double TemperaturaMinima { get; set; }
        public double TemperaturaMaxima { get; set; }
        public int Humedad { get; set; }
        public string Descripcion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int Presion { get; set; }
        public double VelocidadViento { get; set; }
    }
}