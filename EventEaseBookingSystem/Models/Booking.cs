using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEaseBookingSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        // Foreign key for Event
        [Required(ErrorMessage = "Event ID is required")]
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event? Event { get; set; }   // ✅ nullable

        // Foreign key for Venue
        [Required(ErrorMessage = "Venue ID is required")]
        public int VenueId { get; set; }

        [ForeignKey("VenueId")]
        public Venue? Venue { get; set; }   // ✅ nullable

        [Required(ErrorMessage = "Booking date is required")]
        public DateTime BookingDate { get; set; }
    }
}