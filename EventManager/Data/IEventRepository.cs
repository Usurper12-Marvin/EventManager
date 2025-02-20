using EventManager.Models;

namespace EventManager.Data
{
    public interface IEventRepository
    {

        IEnumerable<Attendee> GetAllAttendees();
        Attendee GetAttendeeId(int id);
        void AddAttendee(Attendee attendee);

        IEnumerable<Event> GetAllEvents();
        Event GetEventId(int id);
        void AddEvent(Event _event);
        void Save();
    }
}
