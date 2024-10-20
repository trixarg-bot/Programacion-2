using System;
using System.Collections.Generic;
using System.Linq;

public class ServicioVideojuego
{
    private List<Videojuego> _videojuegos = new List<Videojuego>();
    private int _nextId = 1;

    public event Action OnChange;

    public ServicioVideojuego()
    {
        // Agregar algunos videojuegos de ejemplo
        _videojuegos.Add(new Videojuego { Id = _nextId++, Nombre = "The Legend of Zelda: Breath of the Wild", Desarrollador = "Nintendo", Plataforma = "Switch", Genero = "Aventura", FechaLanzamiento = new DateTime(2017, 3, 3) });
        _videojuegos.Add(new Videojuego { Id = _nextId++, Nombre = "Red Dead Redemption 2", Desarrollador = "Rockstar Games", Plataforma = "PlayStation", Genero = "Acción", FechaLanzamiento = new DateTime(2018, 10, 26) });
    }

    public List<Videojuego> ObtenerTodosLosVideojuegos()
    {
        return _videojuegos;
    }

    public void CrearVideojuego(Videojuego videojuego)
    {
        videojuego.Id = _nextId++;
        _videojuegos.Add(videojuego);
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}