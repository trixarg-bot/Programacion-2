using Microsoft.EntityFrameworkCore;
   using DetenidosMigracion.Models;

   namespace DetenidosMigracion.Data
   {
       public class ApplicationDbContext : DbContext
       {
           public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
           {
           }

           public DbSet<Detenido> detenidos { get; set; }
       }
   }