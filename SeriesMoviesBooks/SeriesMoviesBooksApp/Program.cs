using SeriesMoviesBooksApp; 
using EntertainmentDbService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5074") });

        // Cargar la configuración
        builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        // Configurar servicios
        builder.Services.AddDbContext<EntertainmentDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<EntertainmentService>();



        await builder.Build().RunAsync();
    }
}
