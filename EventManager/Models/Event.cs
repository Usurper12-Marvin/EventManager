using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event Title is required")]
        public string EventTitle { get; set; }

        [Required(ErrorMessage = "Event Description is required")]
        [DisplayName("Description")]
        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Event start date is required")]
        [DisplayName("Start Date")]
        public DateTime EventStartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EventEndDate { get; set; }

        [Required(ErrorMessage = "Event location is required")]
        [DisplayName("Location")]
        public string EventLocation { get; set; }

        [Required(ErrorMessage = "Maximum number of attendees is required")]
        [DisplayName("Available tickets")]
        public int EventMaxAttendees { get; set; }
        public int EventRegistrations { get; set; } = 0;


        public List<Attendee> Attendees { get; set; }
    }
}
