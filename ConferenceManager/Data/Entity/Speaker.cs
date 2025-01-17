﻿using System.Text.Json.Serialization;

namespace ConferenceManager.Data.Entity;

public class Speaker
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("speakerName")]
    public string Name { get; set; }

    [JsonPropertyName("events")]
    public List<int> Events { get; set; }
}
