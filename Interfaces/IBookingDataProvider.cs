using AirportBooking.Models;
namespace AirportBooking.Interfaces
{
    public interface IBookingDataProvider
    {
        void AddBooking(Booking booking);
        void RemoveBooking(int bookingId);
        void UpdateBooking(int bookingId, Booking updatedBooking);
        Booking GetBookingById(int bookingId);
        List<Booking> GetBookingsForPassenger(int passengerId);
        List<Booking> GetAllBookings();
    }
}