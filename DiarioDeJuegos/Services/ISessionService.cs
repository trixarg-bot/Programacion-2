using DiarioDeJuegos.Models;

namespace DiarioDeJuegos.Services;

public interface ISessionService
{
    Usuario? UsuarioActual { get; }
    event Action? OnChange;
    Task LoginUser(Usuario usuario);
    void LogoutUser();
    bool IsAuthenticated();
}