
using ConferenceManager.Data;

namespace ConferenceManager.Controllers;

public class SpeakerService(SpeakerRepository speakerRepository)
{
    private readonly SpeakerRepository _speakerRepository = speakerRepository;
    public List<Speaker> GetSpeakers(int eventId)
    {
        return _speakerRepository.GetSpeakers(eventId);
    }
}