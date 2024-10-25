namespace MigracionAPI.Models.DTOs
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
    }

    public class LoginModel
    {
        public string Identificacion { get; set; }
        public string Clave { get; set; }
    }

    public class ClimaResponse
    {
        public double Temperatura { get; set; }
        public string Descripcion { get; set; }
        public string Ciudad { get; set; }
    }

    public class IncidenciaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pasaporte { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}