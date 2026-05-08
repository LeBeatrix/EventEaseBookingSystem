using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventEaseBookingSystem.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Event date is required")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        // FK to Venue
        public int VenueId { get; set; }

        public Venue? Venue { get; set; } // Navigation property

        // Collection of bookings
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}