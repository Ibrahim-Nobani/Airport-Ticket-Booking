public interface IBookingService
{
    void BookFlight(int flightId, int passengerId, FlightClass flightClass);
    void CancelBooking(int bookingId);
    void ModifyBooking(int bookingId, FlightClass newFlightClass);
    List<Booking> GetPassengerBookings(int passengerId);
}