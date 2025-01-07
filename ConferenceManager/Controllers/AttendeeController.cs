using ConferenceManager.Data.Entity;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendeeController(AttendeeService attendeeService, EventsService eventService) : ControllerBase 
{
    private readonly AttendeeService _attendeeService = attendeeService;

    private readonly EventsService _eventService = eventService;


    [HttpGet]
    public IActionResult GetAttendees()
    {
        var allAttendees = _attendeeService.GetAttendees();
        return Ok(allAttendees);
    }



    [HttpPost]
    public IActionResult AddAttendees(Attendee newAttendee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (_eventService.CheckIdExists(newAttendee.EventId))
        {
            return BadRequest("Event Id does not exists"); 
        }


        // extract sub from event payload for user Id 
        // check User Id exists -> call User Repo 
        // check User Id isn't already attending  -> 
        // add authorisation 
        

        _attendeeService.AddAttendee(newAttendee);
        return Ok(); 
    }




}
