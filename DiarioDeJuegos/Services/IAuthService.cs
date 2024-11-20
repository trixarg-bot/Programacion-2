using DiarioDeJuegos.Models;

namespace DiarioDeJuegos.Services;

public interface IAuthService
{
    Task<bool> RegisterUser(string username, string email, string password);
    Task<Usuario?> Login(string username, string password);
    Task<bool> ValidateUsername(string username);
    Task<bool> ValidateEmail(string email);
}