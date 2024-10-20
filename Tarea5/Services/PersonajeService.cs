using System;
using System.Collections.Generic;
using System.Linq;

public class PersonajeService
{
    private List<Personaje> _personajes = new List<Personaje>();
    private int _nextId = 1;

    public void CrearPersonaje(Personaje personaje)
    {
        personaje.Id = _nextId++;
        _personajes.Add(personaje);
    }

    public List<Personaje> ObtenerTodosLosPersonajes()
    {
        return _personajes;
    }

    public Personaje ObtenerPersonajePorId(int id)
    {
        return _personajes.FirstOrDefault(p => p.Id == id);
    }

    public void ActualizarPersonaje(Personaje personaje)
    {
        var existingPersonaje = _personajes.FirstOrDefault(p => p.Id == personaje.Id);
        if (existingPersonaje != null)
        {
            existingPersonaje.Nombre = personaje.Nombre;
            existingPersonaje.Alias = personaje.Alias;
            existingPersonaje.RolEnJuego = personaje.RolEnJuego;
            existingPersonaje.HabilidadEspecial = personaje.HabilidadEspecial;
            existingPersonaje.ArmaFavorita = personaje.ArmaFavorita;
            existingPersonaje.NivelDePoder = personaje.NivelDePoder;
            existingPersonaje.ImagenUrl = personaje.ImagenUrl;
        }
    }

    public void EliminarPersonaje(int id)
    {
        var personaje = _personajes.FirstOrDefault(p => p.Id == id);
        if (personaje != null)
        {
            _personajes.Remove(personaje);
        }
    }
}