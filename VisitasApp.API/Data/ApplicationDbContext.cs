using Microsoft.EntityFrameworkCore;
using RegistroVisitasAPI.Models;

namespace RegistroVisitasAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Visita> Visitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales si son necesarias
            modelBuilder.Entity<Visita>()
                .Property(v => v.FechaRegistro)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}