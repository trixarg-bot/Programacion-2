using Microsoft.EntityFrameworkCore;
using MigracionAPI.Models;

namespace MigracionAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para Usuario
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Cedula)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Correo)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Telefono)
                .HasMaxLength(20);

            // Configuración para Incidencia
            modelBuilder.Entity<Incidencia>()
                .HasOne(i => i.Agente)
                .WithMany(u => u.Incidencias)
                .HasForeignKey(i => i.CodigoAgente)
                .OnDelete(DeleteBehavior.Restrict); // Cambiamos CASCADE a RESTRICT
        }
    }
}