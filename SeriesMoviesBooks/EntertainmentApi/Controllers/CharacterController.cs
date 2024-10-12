using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly EntertainmentDbContext _context;

    public CharacterController(EntertainmentDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
    {
        return await _context.Characters.Include(c => c.SeriesMovieBook).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacter(int id)
    {
        var character = await _context.Characters
            .Include(c => c.SeriesMovieBook)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (character == null)
        {
            return NotFound();
        }

        return character;
    }

    [HttpPost]
    public async Task<ActionResult<Character>> PostCharacter(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
    }

    //** Implementa los métodos Put y Delete aquí
}