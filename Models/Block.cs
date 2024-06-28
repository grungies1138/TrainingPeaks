using System.Text.Json.Serialization;

namespace TrainingPeaks.Models;

public class Block {
    [JsonPropertyName("exercise_id")]
    public int ExerciseId { get; set; }
    [JsonPropertyName("sets")]
    public List<Set>? Sets { get; set; }
}