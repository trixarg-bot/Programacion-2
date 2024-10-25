using Microsoft.EntityFrameworkCore;
using MigracionAPI.Data;
using MigracionAPI.Models;
using MigracionAPI.Models.DTOs;

namespace MigracionAPI.Services
{
    public class IncidenciasService
    {
        private readonly ApplicationDbContext _context;

        public IncidenciasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> RegistrarIncidencia(RegistroIncidenciaDto dto)
        {
            // Verificar que existe el agente
            var agenteExiste = await _context.Usuarios
                .AnyAsync(u => u.Id == dto.CodigoAgente);

            if (!agenteExiste)
            {
                throw new Exception("El agente especificado no existe.");
            }

            var incidencia = new Incidencia
            {
                Pasaporte = dto.Pasaporte,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                WhatsApp = dto.WhatsApp,
                FechaNacimiento = dto.FechaNacimiento,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                FechaRegistro = DateTime.UtcNow,
                CodigoAgente = dto.CodigoAgente,
                Nacionalidad = dto.Nacionalidad,
                Observaciones = dto.Observaciones,
                EstadoCaso = "Pendiente"
            };

            _context.Incidencias.Add(incidencia);
            await _context.SaveChangesAsync();

            return incidencia.Id;
        }

        public async Task<List<IncidenciaResponseDto>> ObtenerIncidenciasPorAgente(int codigoAgente)
        {
            return await _context.Incidencias
                .Where(i => i.CodigoAgente == codigoAgente)
                .Select(i => new IncidenciaResponseDto
                {
                    Id = i.Id,
                    Pasaporte = i.Pasaporte,
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    WhatsApp = i.WhatsApp,
                    FechaNacimiento = i.FechaNacimiento,
                    Latitud = i.Latitud,
                    Longitud = i.Longitud,
                    FechaRegistro = i.FechaRegistro,
                    Nacionalidad = i.Nacionalidad,
                    Observaciones = i.Observaciones,
                    EstadoCaso = i.EstadoCaso
                })
                .OrderByDescending(i => i.FechaRegistro)
                .ToListAsync();
        }

        public async Task<List<IncidenciaResponseDto>> ObtenerIncidenciasPorID(int id)
        {
            return await _context.Incidencias
                .Where(i => i.Id == id)
                .Select(i => new IncidenciaResponseDto
                {
                    Id = i.Id,
                    Pasaporte = i.Pasaporte,
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    WhatsApp = i.WhatsApp,
                    FechaNacimiento = i.FechaNacimiento,
                    Latitud = i.Latitud,
                    Longitud = i.Longitud,
                    FechaRegistro = i.FechaRegistro,
                    Nacionalidad = i.Nacionalidad,
                    Observaciones = i.Observaciones,
                    EstadoCaso = i.EstadoCaso
                })
                .OrderByDescending(i => i.FechaRegistro)
                .ToListAsync();
        }
    }
}