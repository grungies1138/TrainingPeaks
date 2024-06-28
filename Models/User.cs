using System.Text.Json.Serialization;

namespace TrainingPeaks.Models;

public class User {
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name_first")]
    public string? FirstName { get; set; }
    [JsonPropertyName("name_last")]
    public string? LastName { get; set; }
}