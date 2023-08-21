using System.Collections.Generic;

public interface IBookingFilter
{
    List<Booking> FilterBookings(BookingFilterParameters parameters);
}
