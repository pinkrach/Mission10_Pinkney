using System.Text.Json.Serialization;

namespace backend.Models;

public class Team
{
    public int TeamId { get; set; }
    public string TeamName { get; set; } = null!;
    public int? CaptainId { get; set; }

    [JsonIgnore]
    public List<Bowler> Bowlers { get; set; } = new();
}
