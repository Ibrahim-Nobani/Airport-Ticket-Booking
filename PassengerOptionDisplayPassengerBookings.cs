public class PassengerOptionDisplayPassengerBookings : IPassengerOptions
{
    private IBookingService _bookingService;
    public PassengerOptionDisplayPassengerBookings(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public void Execute()
    {
        int passengerId = 1;
        List<Booking> passengerBookings = _bookingService.GetPassengerBookings(passengerId);
        Console.WriteLine($"Passenger's bookings:");
        passengerBookings.ForEach(booking => Console.WriteLine($"Booking {booking.BookingId}: Flight {booking.FlightId}, Class: {booking.Class} {booking.Price}"));
    }
}