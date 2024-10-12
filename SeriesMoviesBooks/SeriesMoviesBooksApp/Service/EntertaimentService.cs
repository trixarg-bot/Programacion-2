// EntertainmentService.cs

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class EntertainmentService
{
    private readonly HttpClient _httpClient;

    public EntertainmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<SeriesMovieBook>> GetSeriesMovieBooksAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<SeriesMovieBook>>("api/SeriesMovieBook") ?? new List<SeriesMovieBook>();
    }

    public async Task<SeriesMovieBook> GetSeriesMovieBookAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<SeriesMovieBook>($"api/SeriesMovieBook/{id}");
    }

    public async Task<HttpResponseMessage> CreateSeriesMovieBookAsync(SeriesMovieBook seriesMovieBook)
    {
        return await _httpClient.PostAsJsonAsync("api/SeriesMovieBook", seriesMovieBook);
    }

    //** Implementa métodos similares para Characters y otras operaciones CRUD

    public async Task<HttpResponseMessage> CreateCharacterAsync(Character character)
    {
        return await _httpClient.PostAsJsonAsync("api/Character", character);
    }
}