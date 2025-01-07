using ConferenceManager.Data;
using System.Text.Json;

namespace ConferenceManager.Controllers;

public class SpeakerRepository
{
    private List<Speaker> _speakerList;
    private readonly string _path = ".\\Data\\speakers.json";

    public SpeakerRepository()
    {
        _speakerList = GetSpeakersFromFile(_path);
    }

    private List<Speaker>? GetSpeakersFromFile(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Speaker>>(json);
    }
    public List<Speaker> GetSpeakers(int eventId)
        => _speakerList.Where(s => s.EventId == eventId).ToList(); 
}