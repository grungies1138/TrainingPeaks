using System.Text.Json.Serialization;

namespace TrainingPeaks.Models;

public class Workout {
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    [JsonPropertyName("datetime_completed")]
    public DateTime Completed { get; set; }
    [JsonPropertyName("blocks")]
    public List<Block>? Blocks { get; set; }
}