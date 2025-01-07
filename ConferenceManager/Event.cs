using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConferenceManager;

public class Event
{

    public static int IdCounter = 1;

    [JsonPropertyName("id")]
    public int Id { get; set; } = IdCounter++; 


    [JsonPropertyName("title")]
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }


    [JsonPropertyName("date")]
    [Required(ErrorMessage = "Date is required")]
    public DateOnly Date { get; set; }


    [JsonPropertyName("venue")]
    public string Venue { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("category")]
    public string Category { get; set; }
}