using ConferenceManager.Data;
using ConferenceManager.Data.Entity;

namespace ConferenceManager.Services;

public class SpeakerService(SpeakerRepository speakerRepository)
{
    private readonly SpeakerRepository _speakerRepository = speakerRepository;
    public List<Speaker> GetSpeakers(int eventId)
    {
        return _speakerRepository.GetSpeakers(eventId);
    }
}