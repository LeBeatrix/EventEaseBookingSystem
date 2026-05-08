CREATE VIEW BookingDetailsView AS
SELECT
    b.BookingId,
    b.BookingDate,

    e.EventName,
    e.EventDate,
    e.Description,

    v.VenueName,
    v.Location,
    v.Capacity

FROM Bookings b

INNER JOIN Events e
ON b.EventId = e.EventId

INNER JOIN Venues v
ON b.VenueId = v.VenueId;