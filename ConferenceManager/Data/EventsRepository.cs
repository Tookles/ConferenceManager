
using System.Text.Json;

namespace ConferenceManager.Data;

public class EventsRepository
{
    private readonly string _path = ".\\Data\\events.json";

    private List<Event> _eventsInMemory; 

    public EventsRepository()
    {
        _eventsInMemory = ReadEventsFromFile(); 
    }

    private List<Event> ReadEventsFromFile()
    {
        var json = File.ReadAllText(_path);
        var events = JsonSerializer.Deserialize<List<Event>>(json);
        return events;
    }

    public List<Event> GetEvents()
    {
        return _eventsInMemory;
    }

    public Event? GetEventById(int id)
    {
        return _eventsInMemory.FirstOrDefault(e => e.Id == id);
    }


    public void AddEvent(Event newEvent)
    {
        _eventsInMemory.Add(newEvent);
    }

    public bool CheckIdExists(int id)
    {
        return _eventsInMemory.Where(e => e.Id == id).Any(); 
    }
}
