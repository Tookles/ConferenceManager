using ConferenceManager.Data.Entity;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ConferenceManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendeeController(AttendeeService attendeeService, EventsService eventService, UserService userService) : ControllerBase 
{
    private readonly AttendeeService _attendeeService = attendeeService;

    private readonly EventsService _eventService = eventService;

    private readonly UserService _userService = userService;


    [HttpGet]
    public IActionResult GetAttendees()
    {
        var allAttendees = _attendeeService.GetAttendees();
        return Ok(allAttendees);
    }


    [Authorize]
    [HttpPost("{eventId}")]
    public IActionResult AddAttendees(int eventId)
    {
      
        if (!_eventService.CheckIdExists(eventId))
        {
            return BadRequest("Event Id does not exists"); 
        }

        bool checkUserId = Int32.TryParse(HttpContext.User.Claims.First()?.Value, out int userId);

        if (!checkUserId || !_userService.DoesUserExist(userId))
        {
            return BadRequest("Invalid user id");
        }

        if (_attendeeService.CheckAttendance(eventId, userId))
        {
            return BadRequest("User already attending this event");
        }

        Attendee attendeeToAdd = new Attendee() { EventId = eventId, UserId = userId };

        _attendeeService.AddAttendee(attendeeToAdd);

        return NoContent($"/api/attendees/{eventId}", $"{userId} is now attending {eventId}"); 
    }




}
