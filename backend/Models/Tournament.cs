namespace backend.Models;

public class Tournament
{
    public int TourneyId { get; set; }
    public DateOnly? TourneyDate { get; set; }
    public string? TourneyLocation { get; set; }

    public List<TourneyMatch> Matches { get; set; } = new();
}
