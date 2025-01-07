using ConferenceManager.Data;
using ConferenceManager.Data.Entity;

namespace ConferenceManager.Services
{
    public class AttendeeService(AttendeeRepository attendeeRepository)
    {
        private readonly AttendeeRepository _attendeeRepository = attendeeRepository;
    
        public void AddAttendee(Attendee attendee)
        {
            _attendeeRepository.AddAttendee(attendee);
        }

        public List<Attendee> GetAttendees()
        {
            return _attendeeRepository.GetAttendees();
        }
    }
}