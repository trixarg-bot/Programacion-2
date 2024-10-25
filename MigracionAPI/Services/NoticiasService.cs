using System.Text.Json;
using MigracionAPI.Models;

namespace MigracionAPI.Services
{
    public class NoticiasService
    {
        private readonly HttpClient _httpClient;
        private readonly string _noticiasUrl = "https://remolacha.net/wp-json/wp/v2/posts?search=migraci%C3%B3n&_fields=title,excerpt";

        public NoticiasService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Noticia>> ObtenerNoticias()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(_noticiasUrl);
                var noticias = JsonSerializer.Deserialize<List<NoticiaWP>>(response);

                return noticias.Select(n => new Noticia
                {
                    Titulo = n.title.rendered,
                    Resumen = StripHtml(n.excerpt.rendered)
                }).ToList();
            }
            catch (Exception ex)
            {
                // Log the exception
                return new List<Noticia>();
            }
        }

        private string StripHtml(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", String.Empty);
        }

        // Clases auxiliares para deserialización
        private class NoticiaWP
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