using Microsoft.AspNetCore.Mvc;
using MigracionAPI.Models.DTOs;
using MigracionAPI.Services;

namespace MigracionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _usuariosService;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(UsuariosService usuariosService, ILogger<UsuariosController> logger)
        {
            _usuariosService = usuariosService;
            _logger = logger;
        }

        
        /// <summary>
        /// Registra un nuevo agente en el sistema
        /// </summary>
        /// <param name="dto">Datos del agente a registrar</param>
        /// <returns>Información del agente registrado</returns>
        [HttpPost("registro")]
        public async Task<ActionResult<UsuarioResponseDto>> Registro([FromBody] RegistroUsuarioDto dto)
        {
            try
            {
                var resultado = await _usuariosService.Registro(dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }


        // <summary>
        /// Autentica a un agente en el sistema
        /// </summary>
        /// <param name="dto">Credenciales de inicio de sesión</param>
        /// <returns>Información del agente autenticado</returns>
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioResponseDto>> Login([FromBody] LoginDto dto)
        {
            try
            {
                var resultado = await _usuariosService.Login(dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { mensaje = "Credenciales inválidas" });
            }
        }
    }
}