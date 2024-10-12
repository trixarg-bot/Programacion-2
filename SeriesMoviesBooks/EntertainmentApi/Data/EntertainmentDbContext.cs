using Microsoft.EntityFrameworkCore;

public class EntertainmentDbContext : DbContext
{
    public EntertainmentDbContext(DbContextOptions<EntertainmentDbContext> options)
        : base(options)
    {
    }

    public DbSet<SeriesMovieBook> SeriesMovieBooks { get; set; }
    public DbSet<Character> Characters { get; set; }
}