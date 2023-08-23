using AirportBooking.Models;
namespace AirportBooking.Interfaces
{
    public interface IBookingService
    {
        public bool BookFlight(int flightId, int passengerId, FlightClass flightClass);
        public bool CancelBooking(int bookingId);
        public bool ModifyBooking(int bookingId, FlightClass newFlightClass);
        List<Booking> GetPassengerBookings(int passengerId);
    }
}