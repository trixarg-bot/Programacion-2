using Microsoft.AspNetCore.Mvc;
using MigracionAPI.Services;

namespace MigracionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClimaController : ControllerBase
    {
        private readonly ClimaService _climaService;
        private readonly ILogger<ClimaController> _logger;

        public ClimaController(ClimaService climaService, ILogger<ClimaController> logger)
        {
            _climaService = climaService;
            _logger = logger;
        }


        /// <summary>
        /// Obtiene el estado del clima para una ubicación específica dentro de República Dominicana
        /// </summary>
        /// <param name="latitud">Latitud de la ubicación (entre 17.5 y 19.9)</param>
        /// <param name="longitud">Longitud de la ubicación (entre -72.0 y -68.3)</param>
        /// <returns>Información del clima para las coordenadas especificadas</returns>
        [HttpGet]
        public async Task<IActionResult> ObtenerClima([FromQuery] double latitud, [FromQuery] double longitud)
        {
            try
            {
                _logger.LogInformation($"Recibida solicitud de clima para coordenadas: {latitud}, {longitud}");

                // Validar coordenadas
                if (latitud < 17.5 || latitud > 19.9 || longitud < -72.0 || longitud > -68.3)
                {
                    return BadRequest("Las coordenadas están fuera del territorio de la República Dominicana");
                }

                var resultado = await _climaService.ObtenerClima(latitud, longitud);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener clima: {ex.Message}");
                return StatusCode(500, "Error al obtener datos del clima");
            }
        }
    }
}