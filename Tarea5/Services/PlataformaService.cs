using System;
using System.Collections.Generic;
using System.Linq;

public class PlataformaService
{
    private List<Plataforma> _plataformas = new List<Plataforma>();
    private int _nextId = 1;

    public PlataformaService()
    {
        // Agregar algunas plataformas de ejemplo
        _plataformas.Add(new Plataforma { Id = _nextId++, Nombre = "PC", Activa = true });
        _plataformas.Add(new Plataforma { Id = _nextId++, Nombre = "PS5", Activa = true });
        _plataformas.Add(new Plataforma { Id = _nextId++, Nombre = "Xbox Series X", Activa = true });
    }

    public List<Plataforma> ObtenerTodasLasPlataformas()
    {
        return _plataformas;
    }

    public Plataforma ObtenerPlataformaPorId(int id)
    {
        return _plataformas.FirstOrDefault(p => p.Id == id);
    }

    public void CrearPlataforma(Plataforma plataforma)
    {
        plataforma.Id = _nextId++;
        _plataformas.Add(plataforma);
    }

    public void ActualizarPlataforma(Plataforma plataforma)
    {
        var existingPlataforma = _plataformas.FirstOrDefault(p => p.Id == plataforma.Id);
        if (existingPlataforma != null)
        {
            existingPlataforma.Nombre = plataforma.Nombre;
            existingPlataforma.Activa = plataforma.Activa;
        }
    }

    public void EliminarPlataforma(int id)
    {
        var plataforma = _plataformas.FirstOrDefault(p => p.Id == id);
        if (plataforma != null)
        {
            _plataformas.Remove(plataforma);
        }
    }
}