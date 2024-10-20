using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Tarea5;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<PlataformaService>();
builder.Services.AddSingleton<PersonajeService>();
builder.Services.AddSingleton<ServicioVideojuego>();

// builder.Services.AddDbContext<AppDbContext>(options =>
//             options.UseSqlite("Data Source=videojuegos.db"));

await builder.Build().RunAsync();
