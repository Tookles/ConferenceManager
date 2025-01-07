using ConferenceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpeakerController(SpeakerService speakerService) : ControllerBase
{
    private readonly SpeakerService _speakerService = speakerService;

    [HttpGet("{eventId}")]
    public IActionResult GetSpeakers(int eventId)
        => Ok(_speakerService.GetSpeakers(eventId));

}
