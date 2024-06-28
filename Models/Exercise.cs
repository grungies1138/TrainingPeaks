using System.Text.Json.Serialization;

namespace TrainingPeaks.Models;

public class Exercise 
{
    [JsonPropertyName("id")]    
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string? Title { get; set; }
}