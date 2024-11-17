using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Migracionapp.Models;

namespace Migracionapp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Detenido> detenidos {get; set;}

    }
}