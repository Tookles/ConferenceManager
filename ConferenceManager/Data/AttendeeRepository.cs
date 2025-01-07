using System.Text.Json;
using ConferenceManager.Data.Entity;

namespace ConferenceManager.Data
{
    public class AttendeeRepository
    {
        private List<Attendee> _attendeeList;

        private readonly string _path = ".\\Data\\attendees.json";

        public AttendeeRepository()
        {
            _attendeeList = GetAttendeesFromFile(_path);
        }

        private List<Attendee>? GetAttendeesFromFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Attendee>>(json);
        }

        public List<Attendee> GetAttendees()
        {
            return _attendeeList;
        }

        public void AddAttendee(Attendee newAttendee)
        {
            _attendeeList.Add(newAttendee); 
        }
    }
}