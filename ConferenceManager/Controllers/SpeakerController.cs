using ConferenceManager.Data.Entity;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpeakerController(SpeakerService speakerService, EventsService eventsService) : ControllerBase
{
    private readonly SpeakerService _speakerService = speakerService;

    private readonly EventsService _eventService = eventsService; 

    [HttpGet("{eventId}")]
    public IActionResult GetSpeakers(int eventId)
        => Ok(_speakerService.GetSpeakers(eventId));


    [HttpDelete("{speakerId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteSpeaker(int speakerId, [FromBody] int eventId)
    {
        _speakerService.DeleteSpeaker(eventId, speakerId);
        return NoContent();
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddSpeaker(Speaker speakerToAdd)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _speakerService.AddSpeaker(speakerToAdd);
        return Created("/addspeaker", "Speaker added");
    }

    [HttpPatch("{speakerId}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateSpeaker(int speakerId, [FromBody] int eventId)
    {
        if (!_eventService.CheckIdExists(eventId))
        {
            return BadRequest("This event does not exist");
        }
        _speakerService.AddEvent(eventId, speakerId);
        return Ok(); 
    }


}
