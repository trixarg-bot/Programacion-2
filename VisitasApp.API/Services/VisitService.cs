using Microsoft.EntityFrameworkCore;
using RegistroVisitasAPI.Data;
using RegistroVisitasAPI.Models;
using RegistroVisitasAPI.Models.DTOs;

namespace RegistroVisitasAPI.Services
{
    public class VisitasService
    {
        private readonly ApplicationDbContext _context;

        public VisitasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VisitaResponseDto> RegistrarVisita(RegistroVisitaDto dto)
        {
            var visita = new Visita
            {
                Telefono = dto.Telefono,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                FechaRegistro = DateTime.Now
            };

            _context.Visitas.Add(visita);
            await _context.SaveChangesAsync();

            return new VisitaResponseDto
            {
                Id = visita.Id,
                Telefono = visita.Telefono,
                Nombre = visita.Nombre,
                Apellido = visita.Apellido,
                Correo = visita.Correo,
                FechaRegistro = visita.FechaRegistro
            };
        }

        public async Task<List<VisitaResponseDto>> ObtenerVisitas()
        {
            return await _context.Visitas
                .OrderByDescending(v => v.FechaRegistro)
                .Select(v => new VisitaResponseDto
                {
                    Id = v.Id,
                    Telefono = v.Telefono,
                    Nombre = v.Nombre,
                    Apellido = v.Apellido,
                    Correo = v.Correo,
                    FechaRegistro = v.FechaRegistro
                })
                .ToListAsync();
        }
    }
}
