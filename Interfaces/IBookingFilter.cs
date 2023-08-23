using AirportBooking.Models;
namespace AirportBooking.Interfaces
{
    public interface IBookingFilter
    {
        List<Booking> FilterBookings(BookingFilterParameters parameters);
    }
}
