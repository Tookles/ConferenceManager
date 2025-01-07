using ConferenceManager.Data;

namespace ConferenceManager.Services;

public class EventsService(EventsRepository eventsRepository)
{
    private readonly EventsRepository _eventsRepository = eventsRepository;
    public List<Event> GetEvents()
    {
        return _eventsRepository.GetEvents();
    }

    public Event? GetEventById(int id)
    {
        return _eventsRepository.GetEventById(id);
    }

    public void AddEvent(Event newEvent)
    {
        _eventsRepository.AddEvent(newEvent); 
    }
}