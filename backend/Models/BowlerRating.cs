namespace backend.Models;

public class BowlerRating
{
    public string BowlerRatingText { get; set; } = null!;
    public short? BowlerLowAvg { get; set; }
    public short? BowlerHighAvg { get; set; }
}
