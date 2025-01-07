using System.Text.Json.Serialization;

namespace ConferenceManager;

public class Event
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("date")]
    public DateOnly Date { get; set; }
    [JsonPropertyName("venue")]
    public string Venue { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("category")]
    public string Category { get; set; }
}