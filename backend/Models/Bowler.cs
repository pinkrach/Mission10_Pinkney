namespace backend.Models;

public class Bowler
{
    public int BowlerId { get; set; }
    public string? BowlerLastName { get; set; }
    public string? BowlerFirstName { get; set; }
    public string? BowlerMiddleInit { get; set; }
    public string? BowlerAddress { get; set; }
    public string? BowlerCity { get; set; }
    public string? BowlerState { get; set; }
    public string? BowlerZip { get; set; }
    public string? BowlerPhoneNumber { get; set; }
    public int? TeamId { get; set; }

    public Team? Team { get; set; }
    public List<BowlerScore> Scores { get; set; } = new();
}
