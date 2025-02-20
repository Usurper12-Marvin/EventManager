using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Models
{
    public class Attendee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendeeId {get;set;}

        [Required(ErrorMessage ="Please enter your name")]
        public string AttendeeName { get;set;}

        [Required(ErrorMessage ="Please enter a valid email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Email format is invalid.")]
        public string AttendeeEmail { get; set; }

        [Required]
        public int EventId { get;set;}

        [ForeignKey("EventId")]
        public Event Events { get;set;}
    }
}
