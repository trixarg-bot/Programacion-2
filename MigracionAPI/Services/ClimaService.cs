using System.Text.Json;
using System.Text.Json.Serialization;
using MigracionAPI.Models.DTOs;

namespace MigracionAPI.Services
{
    public class ClimaService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ClimaService> _logger;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public ClimaService(
            HttpClient httpClient, 
            IConfiguration configuration,
            ILogger<ClimaService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _apiKey = _configuration["WeatherAPI:ApiKey"];
            _baseUrl = _configuration["WeatherAPI:BaseUrl"];
        }

        public async Task<ClimaResponseDto> ObtenerClima(double latitud, double longitud)
        {
            try
            {
                // Asegurarse de que la URL incluya la solicitud del nombre de la ciudad
                var url = $"{_baseUrl}weather?lat={latitud}&lon={longitud}&appid={_apiKey}&units=metric&lang=es";
                _logger.LogInformation($"Llamando a URL: {url}");

                var response = await _httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"Respuesta recibida: {content}");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                var weatherData = JsonSerializer.Deserialize<OpenWeatherMapResponse>(content, options);

                if (weatherData?.Main == null)
                {
                    throw new Exception($"Datos del clima no disponibles. Respuesta: {content}");
                }

                // Intentar obtener el nombre de la ciudad desde sys.country si name está vacío
                var ciudad = !string.IsNullOrEmpty(weatherData.Name) 
                    ? weatherData.Name 
                    : weatherData.Sys?.Country ?? "Ubicación desconocida";

                return new ClimaResponseDto
                {
                    Temperatura = Math.Round(weatherData.Main.Temp, 1),
                    TemperaturaMinima = Math.Round(weatherData.Main.TempMin, 1),
                    TemperaturaMaxima = Math.Round(weatherData.Main.TempMax, 1),
                    Humedad = weatherData.Main.Humidity,
                    Descripcion = weatherData.Weather?.FirstOrDefault()?.Description ?? "No disponible",
                    Ciudad = ciudad,
                    Presion = weatherData.Main.Pressure,
                    VelocidadViento = weatherData.Wind?.Speed ?? 0,
                    Pais = weatherData.Sys?.Country ?? "Desconocido"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error completo: {ex}");
                throw;
            }
        }

        private class OpenWeatherMapResponse
        {
            [JsonPropertyName("main")]
            public MainData Main { get; set; }

            [JsonPropertyName("weather")]
            public WeatherData[] Weather { get; set; }

            [JsonPropertyName("wind")]
            public WindData Wind { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("sys")]
            public SysData Sys { get; set; }
        }

        private class MainData
        {
            [JsonPropertyName("temp")]
            public float Temp { get; set; }

            [JsonPropertyName("temp_min")]
            public float TempMin { get; set; }

            [JsonPropertyName("temp_max")]
            public float TempMax { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }

            [JsonPropertyName("pressure")]
            public int Pressure { get; set; }
        }

        private class WeatherData
        {
            [JsonPropertyName("description")]
            public string Description { get; set; }
        }

        private class WindData
        {
            [JsonPropertyName("speed")]
            public float Speed { get; set; }
        }

        private class SysData
        {
            [JsonPropertyName("country")]
            public string Country { get; set; }
        }
    }
}