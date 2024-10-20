// using Microsoft.EntityFrameworkCore;

// public class AppDbContext : DbContext
// {
//     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//     public DbSet<Videojuego> Videojuegos { get; set; }
//     public DbSet<Plataforma> Plataformas { get; set; }
//     public DbSet<Personaje> Personajes { get; set; }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Videojuego>()
//             .HasOne(v => v.Plataforma)
//             .WithMany(p => p.Videojuegos)
//             .HasForeignKey(v => v.PlataformaId);

//         modelBuilder.Entity<Personaje>()
//             .HasOne(p => p.Videojuego)
//             .WithMany(v => v.Personajes)
//             .HasForeignKey(p => p.VideojuegoId);
//     }
// }