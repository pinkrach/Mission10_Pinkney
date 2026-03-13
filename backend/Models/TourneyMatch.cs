namespace backend.Models;

public class TourneyMatch
{
    public int MatchId { get; set; }
    public int? TourneyId { get; set; }
    public string? Lanes { get; set; }
    public int? OddLaneTeamId { get; set; }
    public int? EvenLaneTeamId { get; set; }

    public Tournament? Tournament { get; set; }
    public Team? OddLaneTeam { get; set; }
    public Team? EvenLaneTeam { get; set; }

    public List<MatchGame> Games { get; set; } = new();
}
