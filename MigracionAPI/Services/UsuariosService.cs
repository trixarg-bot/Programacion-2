using Microsoft.EntityFrameworkCore;
using MigracionAPI.Data;
using MigracionAPI.Models;
using MigracionAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace MigracionAPI.Services
{
    public class UsuariosService
    {
        private readonly ApplicationDbContext _context;

        public UsuariosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioResponseDto> Registro(RegistroUsuarioDto dto)
        {
            var existeUsuario = await _context.Usuarios
                .AnyAsync(u => u.Cedula == dto.Cedula || u.Correo == dto.Correo);

            if (existeUsuario)
            {
                throw new Exception("Ya existe un usuario con esta cédula o correo.");
            }

            var usuario = new Usuario
            {
                Cedula = dto.Cedula,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Clave = HashPassword(dto.Clave)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Cedula = usuario.Cedula,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                Correo = usuario.Correo
            };
        }

        public async Task<UsuarioResponseDto> Login(LoginDto dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Cedula == dto.Identificacion || 
                                        u.Correo == dto.Identificacion);

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            if (!VerifyPassword(dto.Clave, usuario.Clave))
            {
                throw new Exception("Contraseña incorrecta.");
            }

            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Cedula = usuario.Cedula,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                Correo = usuario.Correo
            };
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
}