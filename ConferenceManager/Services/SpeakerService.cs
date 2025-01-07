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

    public void DeleteSpeaker(int eventId, int speakerId)
    {
        _speakerRepository.DeleteSpeaker(eventId, speakerId);
    }

    public void AddSpeaker(Speaker speakerToAdd)
    {
        _speakerRepository.AddSpeaker(speakerToAdd);
    }

    public void AddEvent(int eventId, int speakerId)
    {
        _speakerRepository.AddEvent(eventId, speakerId);
    }
}