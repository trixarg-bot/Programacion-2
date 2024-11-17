using Microsoft.AspNetCore.Mvc;
using RegistroVisitasAPI.Models.DTOs;
using RegistroVisitasAPI.Services;

namespace RegistroVisitasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitasController : ControllerBase
    {
        private readonly VisitasService _visitasService;
        private readonly ILogger<VisitasController> _logger;

        public VisitasController(VisitasService visitasService, ILogger<VisitasController> logger)
        {
            _visitasService = visitasService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<VisitaResponseDto>> RegistrarVisita([FromBody] RegistroVisitaDto dto)
        {
            try
            {
                var resultado = await _visitasService.RegistrarVisita(dto);
                _logger.LogInformation($"Visita registrada con ID: {resultado.Id}");
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al registrar visita: {ex.Message}");
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<VisitaResponseDto>>> ObtenerVisitas()
        {
            try
            {
                var visitas = await _visitasService.ObtenerVisitas();
                return Ok(visitas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener visitas: {ex.Message}");
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}