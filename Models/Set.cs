using System.Text.Json.Serialization;

namespace TrainingPeaks.Models;

public class Set {
    [JsonPropertyName("reps")]
    public int Reps { get; set; }
    [JsonPropertyName("weight")]
    public int? Weight { get; set; }
}