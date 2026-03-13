using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly BowlingLeagueContext _context;

    public TeamsController(BowlingLeagueContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Team>>> GetAll()
    {
        return await _context.Teams
            .Include(t => t.Bowlers)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Team>> Get(int id)
    {
        var team = await _context.Teams
            .Include(t => t.Bowlers)
            .FirstOrDefaultAsync(t => t.TeamId == id);

        if (team == null)
            return NotFound();

        return team;
    }
}
