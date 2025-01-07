using System.Text.Json;
using ConferenceManager.Data.Entity;

namespace ConferenceManager.Data;

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
        => _speakerList.Where(s => s.Events.Contains(eventId)).ToList();

    public void DeleteSpeaker(int eventId, int speakerId)
    {
        Speaker speakerToDelete = _speakerList.Where(s => s.Id == speakerId).First(); 
        speakerToDelete.Events.Remove(eventId);
    }

    public void AddSpeaker(Speaker speakerToAdd)
    {
        _speakerList.Add(speakerToAdd);
    }

    public void AddEvent(int eventId, int speakerId)
    {
        _speakerList.Where(s => s.Id == speakerId).First().Events.Add(eventId); 
    }
}