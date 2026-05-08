using Microsoft.EntityFrameworkCore;
using EventEaseBookingSystem.Models;
using EventEaseBookingSystem.Models.ViewModels;

namespace EventEaseBookingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetailsViewModel> BookingDetailsView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Booking -> Event
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings) // specify collection
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Restrict); // avoid cascade conflicts

            // Booking -> Venue
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Venue)
                .WithMany(v => v.Bookings) // specify collection
                .HasForeignKey(b => b.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            // Event -> Venue
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingDetailsViewModel>()
                .HasNoKey()
                .ToView("BookingDetailsView");
        }
    }
}