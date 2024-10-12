using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class SeriesMovieBookController : ControllerBase
{
    private readonly EntertainmentDbContext _context;

    public SeriesMovieBookController(EntertainmentDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SeriesMovieBook>>> GetSeriesMovieBooks()
    {
        return await _context.SeriesMovieBooks.Include(s => s.Characters).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SeriesMovieBook>> GetSeriesMovieBook(int id)
    {
        var seriesMovieBook = await _context.SeriesMovieBooks
            .Include(s => s.Characters)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (seriesMovieBook == null)
        {
            return NotFound();
        }

        return seriesMovieBook;
    }

    [HttpPost]
    public async Task<ActionResult<SeriesMovieBook>> PostSeriesMovieBook(SeriesMovieBook seriesMovieBook)
    {
        _context.SeriesMovieBooks.Add(seriesMovieBook);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSeriesMovieBook), new { id = seriesMovieBook.Id }, seriesMovieBook);
    }

    //** Implementa los métodos Put y Delete aquí
}
