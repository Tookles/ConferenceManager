
using System.Text.Json;

namespace ConferenceManager.Data;

public class EventsRepository
{
    private readonly string _path = ".\\Data\\events.json";
    public List<Event> GetEvents()
    {
        var json = File.ReadAllText(_path);
        var events = JsonSerializer.Deserialize<List<Event>>(json);

        return events;
    }

    public Event? GetEventById(int id)
    {
        var events = GetEvents();
        return events.FirstOrDefault(e => e.Id == id);
    }
}
