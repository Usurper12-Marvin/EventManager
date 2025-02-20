using EventManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public IActionResult Index()
        {
            var _events = _eventRepository.GetAllEvents().OrderBy(s => s.EventStartDate); ;
            return View(_events);
        }
        public IActionResult Details(int id)
        {
            var _event = _eventRepository.GetEventId(id);
            return View(_event);
        }

    }
}
