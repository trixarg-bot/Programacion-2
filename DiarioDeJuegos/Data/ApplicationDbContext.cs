using Microsoft.EntityFrameworkCore;
using DiarioDeJuegos.Models;

namespace DiarioDeJuegos.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Vivencia> Vivencias => Set<Vivencia>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.NombreUsuario)
            .IsUnique();

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Vivencia>()
            .HasOne(v => v.Usuario)
            .WithMany(u => u.Vivencias)
            .HasForeignKey(v => v.UsuarioId);
    }
}