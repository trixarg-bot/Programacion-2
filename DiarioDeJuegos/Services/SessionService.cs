using DiarioDeJuegos.Models;

namespace DiarioDeJuegos.Services;

public class SessionService : ISessionService
{
    private Usuario? _usuarioActual;
    public Usuario? UsuarioActual => _usuarioActual;

    public event Action? OnChange;

    public async Task LoginUser(Usuario usuario)
    {
        _usuarioActual = usuario;
        OnChange?.Invoke();
    }

    public void LogoutUser()
    {
        _usuarioActual = null;
        OnChange?.Invoke();
    }

    public bool IsAuthenticated()
    {
        return _usuarioActual != null;
    }
}