using System.Text.Json.Serialization;

namespace ConferenceManager.Data.Entity;

public class Attendee
{
    [JsonPropertyName("eventId")]
    public int EventId { get; set; }

    [JsonPropertyName("userId")]
    public int UserId { get; set; }
}
