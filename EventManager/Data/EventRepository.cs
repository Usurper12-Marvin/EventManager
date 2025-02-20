using EventManager.Models;

namespace EventManager.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly EntityDbContext _entityDbConext;
        public EventRepository(EntityDbContext entityDbContext)
        {
            _entityDbConext = entityDbContext;
        }
        public void AddAttendee(Attendee attendee)
        {
            _entityDbConext.Attendees.Add(attendee);
        }

        public void AddEvent(Event _event)
        {
            _entityDbConext.Events.Add(_event);
        }

        public IEnumerable<Attendee> GetAllAttendees()
        {
            return _entityDbConext.Attendees;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _entityDbConext.Events;
        }

        public Attendee GetAttendeeId(int id)
        {
            return _entityDbConext.Attendees.FirstOrDefault(s => s.AttendeeId == id);
        }

        public Event GetEventId(int id)
        {
            return _entityDbConext.Events.FirstOrDefault(s => s.EventId == id);
        }

        public void Save()
        {
            _entityDbConext.SaveChanges(); 
        }
    }
}
