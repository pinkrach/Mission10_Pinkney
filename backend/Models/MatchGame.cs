namespace backend.Models;

public class MatchGame
{
    public int MatchId { get; set; }
    public short GameNumber { get; set; }
    public int? WinningTeamId { get; set; }

    public TourneyMatch? Match { get; set; }
}
