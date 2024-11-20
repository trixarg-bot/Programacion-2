using DiarioDeJuegos.Data;
using DiarioDeJuegos.Models;
using Microsoft.EntityFrameworkCore;

namespace DiarioDeJuegos.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;

    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterUser(string username, string email, string password)
    {
        if (await ValidateUsername(username) || await ValidateEmail(email))
            return false;

        var usuario = new Usuario
        {
            NombreUsuario = username,
            Email = email,
            ClaveHash = BCrypt.Net.BCrypt.HashPassword(password)
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Usuario?> Login(string username, string password)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.NombreUsuario == username);

        if (usuario == null)
            return null;

        bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, usuario.ClaveHash);
        return isValidPassword ? usuario : null;
    }

    public async Task<bool> ValidateUsername(string username)
    {
        return await _context.Usuarios.AnyAsync(u => u.NombreUsuario == username);
    }

    public async Task<bool> ValidateEmail(string email)
    {
        return await _context.Usuarios.AnyAsync(u => u.Email == email);
    }
}