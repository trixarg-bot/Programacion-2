namespace MigracionAPI.Models.DTOs
{
    public class RegistroUsuarioDto
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }

    public class LoginDto
    {
        public string Identificacion { get; set; }
        public string Clave { get; set; }
    }

    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}