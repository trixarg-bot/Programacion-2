using Microsoft.AspNetCore.Mvc;
using MigracionAPI.Models.DTOs;
using MigracionAPI.Services;

namespace MigracionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidenciasController : ControllerBase
    {
        private readonly IncidenciasService _incidenciasService;
        private readonly ILogger<IncidenciasController> _logger;

        public IncidenciasController(IncidenciasService incidenciasService, ILogger<IncidenciasController> logger)
        {
            _incidenciasService = incidenciasService;
            _logger = logger;
        }

        // <summary>
        /// Registra una nueva incidencia en el sistema
        /// </summary>
        /// <param name="dto">Datos de la incidencia a registrar</param>
        /// <returns>ID de la incidencia registrada y mensaje de confirmación</returns>
        [HttpPost]
        public async Task<ActionResult<int>> RegistrarIncidencia([FromBody] RegistroIncidenciaDto dto)
        {
            try
            {
                var id = await _incidenciasService.RegistrarIncidencia(dto);
                _logger.LogInformation($"Incidencia registrada con ID: {id}");
                return Ok(new { Id = id, Mensaje = "Incidencia registrada exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al registrar incidencia: {ex.Message}");
                return BadRequest(new { mensaje = ex.Message });
            }
        }


        /// <summary>
        /// Obtiene todas las incidencias registradas por un agente específico
        /// </summary>
        /// <param name="codigoAgente">ID del agente</param>
        /// <returns>Lista de incidencias del agente</returns>
        [HttpGet("agente/{codigoAgente}")]
        public async Task<ActionResult<List<IncidenciaResponseDto>>> ObtenerPorAgente(int codigoAgente)
        {
            try
            {
                var incidencias = await _incidenciasService.ObtenerIncidenciasPorAgente(codigoAgente);
                return Ok(incidencias);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener incidencias: {ex.Message}");
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        
        
        /// <summary>
        /// Busca y retorna una incidencia específica por su ID
        /// </summary>
        /// <param name="id">ID de la incidencia a buscar</param>
        /// <returns>Detalles de la incidencia solicitada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidenciaResponseDto>> GetById(int id)
        {
            try
            {
                var incidencias = await _incidenciasService.ObtenerIncidenciasPorID(id);
                return Ok(incidencias);
                    // .FirstOrDefaultAsync(i => i.Id == id);

                if (incidencias == null)
                {
                    return NotFound($"No se encontró la incidencia con ID: {id}");
                }

                return Ok(incidencias);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener incidencia: {ex.Message}");
                return StatusCode(500, "Error interno al obtener la incidencia");
            }
        }
    }
}