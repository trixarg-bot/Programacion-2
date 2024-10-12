using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntertainmentDbService;
public class EntertainmentDbContext : DbContext
{
    public DbSet<SeriesMovieBook> SeriesMovieBooks { get; set; }
    public DbSet<Character> Characters { get; set; }

    public EntertainmentDbContext(DbContextOptions<EntertainmentDbContext> options)
        : base(options)
    {
    }
}

public class EntertainmentService
{
    private readonly EntertainmentDbContext _context;

    public EntertainmentService(EntertainmentDbContext context)
    {
        _context = context;
    }

    //** CRUD para SeriesMovieBook
    public async Task<List<SeriesMovieBook>> GetAllSeriesMovieBooksAsync()
    {
        return await _context.SeriesMovieBooks.Include(s => s.Characters).ToListAsync();
    }

    public async Task<SeriesMovieBook> GetSeriesMovieBookByIdAsync(int id)
    {
        return await _context.SeriesMovieBooks.Include(s => s.Characters).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<SeriesMovieBook> AddSeriesMovieBookAsync(SeriesMovieBook seriesMovieBook)
    {
        _context.SeriesMovieBooks.Add(seriesMovieBook);
        await _context.SaveChangesAsync();
        return seriesMovieBook;
    }

    public async Task<SeriesMovieBook> UpdateSeriesMovieBookAsync(SeriesMovieBook seriesMovieBook)
    {
        _context.Entry(seriesMovieBook).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return seriesMovieBook;
    }

    public async Task DeleteSeriesMovieBookAsync(int id)
    {
        var seriesMovieBook = await _context.SeriesMovieBooks.FindAsync(id);
        if (seriesMovieBook != null)
        {
            _context.SeriesMovieBooks.Remove(seriesMovieBook);
            await _context.SaveChangesAsync();
        }
    }

    //** CRUD para Character
    public async Task<List<Character>> GetAllCharactersAsync()
    {
        return await _context.Characters.Include(c => c.SeriesMovieBook).ToListAsync();
    }

    public async Task<Character> GetCharacterByIdAsync(int id)
    {
        return await _context.Characters.Include(c => c.SeriesMovieBook).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Character> AddCharacterAsync(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
        return character;
    }

    public async Task<Character> UpdateCharacterAsync(Character character)
    {
        _context.Entry(character).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return character;
    }

    public async Task DeleteCharacterAsync(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character != null)
        {
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
    }
}