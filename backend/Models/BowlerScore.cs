namespace backend.Models;

public class BowlerScore
{
    public int MatchId { get; set; }
    public short GameNumber { get; set; }
    public int BowlerId { get; set; }
    public short? RawScore { get; set; }
    public short? HandiCapScore { get; set; }
    public bool WonGame { get; set; }

    public Bowler? Bowler { get; set; }
}
