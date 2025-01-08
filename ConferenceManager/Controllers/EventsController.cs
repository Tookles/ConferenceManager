using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController(EventsService eventsService) : ControllerBase
{
    private readonly EventsService _eventsService = eventsService;

    [HttpGet]
    public IActionResult GetEvents()
    {
        return Ok(_eventsService.GetEvents());
    }

    [HttpGet("{id}")]
    public IActionResult GetEventById(int id)
    {
        return Ok(_eventsService.GetEventById(id));
    }

    [HttpPost]
    //[Authorize]
    public IActionResult AddEvent(Event newEvent)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _eventsService.AddEvent(newEvent);
        return NoContent(); 
    }


}
