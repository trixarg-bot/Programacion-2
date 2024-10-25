using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http;
using System.Web;

namespace MigracionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoticiasController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<NoticiasController> _logger;

        public NoticiasController(HttpClient httpClient, ILogger<NoticiasController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        /// <summary>
        /// Obtiene las últimas noticias relacionadas con migración
        /// </summary>
        /// <returns>Lista de noticias con título, resumen y fecha de publicación</returns>
        [HttpGet]
        public async Task<IActionResult> GetNoticias()
        {
            try
            {
                var url = "https://remolacha.net/wp-json/wp/v2/posts?search=migraci%C3%B3n&_fields=title,excerpt";
                var response = await _httpClient.GetAsync(url);
                
                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, "Error al obtener noticias");
                }

                var content = await response.Content.ReadAsStringAsync();
                var noticias = JsonSerializer.Deserialize<List<WordPressNoticia>>(content);

                var noticiasFormateadas = noticias.Select(n => new
                {
                    Titulo = StripHtml(HttpUtility.HtmlDecode(n.title.rendered)).Trim(),
                    Resumen = StripHtml(HttpUtility.HtmlDecode(n.excerpt.rendered)).Trim(),
                    FechaPublicacion = DateTime.Now.ToString("dd/MM/yyyy")
                }).ToList();

                return Ok(noticiasFormateadas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener noticias: {ex.Message}");
                return StatusCode(500, "Error interno al obtener noticias");
            }
        }

        private string StripHtml(string input)
        {
            // Primero decodificar entidades HTML
            var decoded = HttpUtility.HtmlDecode(input);
            
            // Luego remover etiquetas HTML
            var withoutTags = System.Text.RegularExpressions.Regex.Replace(decoded, "<[^>]+>", "");
            
            // Remover espacios múltiples y saltos de línea
            var cleaned = System.Text.RegularExpressions.Regex.Replace(withoutTags, @"\s+", " ");
            
            return cleaned.Trim();
        }

        private class WordPressNoticia
        {
            public Title title { get; set; }
            public Excerpt excerpt { get; set; }
        }

        private class Title
        {
            public string rendered { get; set; }
        }

        private class Excerpt
        {
            public string rendered { get; set; }
        }
    }
}