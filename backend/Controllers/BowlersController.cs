using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BowlersController : ControllerBase
{
    private readonly BowlingLeagueContext _context;

    public BowlersController(BowlingLeagueContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bowler>>> GetAll()
    {
        return await _context.Bowlers
            .Include(b => b.Team)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bowler>> Get(int id)
    {
        var bowler = await _context.Bowlers
            .Include(b => b.Team)
            .FirstOrDefaultAsync(b => b.BowlerId == id);

        if (bowler == null)
            return NotFound();

        return bowler;
    }
}
