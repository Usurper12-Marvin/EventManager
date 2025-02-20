using EventManager.Data;
using EventManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private EntityDbContext _entityDbContext;
        private UserManager<IdentityUser> _userManager;
        public AttendeeController(IEventRepository eventRepository, EntityDbContext entityDbContext, UserManager<IdentityUser> userManager)
        {
            _eventRepository = eventRepository;
            _entityDbContext = entityDbContext;
            _userManager = userManager;
        }
        public IActionResult List()
        {
            var _event = _eventRepository.GetAllAttendees();
            return View(_event);
        }
        public IActionResult Confirmation()
        {
            var attendees = new Event();
            attendees.EventRegistrations++;
            return View();
        }
        [HttpGet]
        public IActionResult AttendeeReg(int EventID)
        {
            //var Event = _eventRepository.GetEventId(eventID);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AttendeeReg(Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                //var Event = _eventRepository.GetEventId(EventId);
                attendee = new Attendee
                {
                    AttendeeName = user.UserName,
                    AttendeeEmail = user.Email
                };
                _eventRepository.AddAttendee(attendee);

                return RedirectToAction("Confirmation");

            }

            return View(attendee);
        }
    }
}
