using Microsoft.EntityFrameworkCore;
using APPMigracion.Models;

   namespace APPMigracion.Data
   {
       public class ApplicationDbContext : DbContext
       {
           public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
           {
           }

           public DbSet<Detenido> detenidos { get; set; }
       }
   }