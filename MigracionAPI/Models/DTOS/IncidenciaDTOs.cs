namespace MigracionAPI.Models.DTOs
{
    public class RegistroIncidenciaDto
    {
        public string Pasaporte { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string WhatsApp { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int CodigoAgente { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Observaciones { get; set; }
    }

    public class IncidenciaResponseDto
    {
        public int Id { get; set; }
        public string Pasaporte { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string WhatsApp { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Observaciones { get; set; }
        public string? EstadoCaso { get; set; }
    }
}