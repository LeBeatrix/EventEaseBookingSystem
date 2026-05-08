using System;

namespace EventEaseBookingSystem.Models.ViewModels
{
    public class BookingDetailsViewModel
    {
        public int BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public string VenueName { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }
    }
}