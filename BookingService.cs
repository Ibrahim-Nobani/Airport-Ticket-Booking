public class BookingService : IBookingService
{
    private IBookingDataProvider _bookingDataProvider;
    private IFlightDataProvider _flightDataProvider;

    public BookingService(IBookingDataProvider bookingDataProvider, IFlightDataProvider flightDataProvider)
    {
        _bookingDataProvider = bookingDataProvider;
        _flightDataProvider = flightDataProvider;
    }

    public void BookFlight(int flightId, int passengerId, FlightClass flightClass)
    {
        Flight flight = _flightDataProvider.GetFlightById(flightId);
        if (flight == null)
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        if (!flight.ClassPrices.ContainsKey(flightClass))
        {
            Console.WriteLine("Invalid class selected.");
            return;
        }

        decimal selectedClassPrice = flight.ClassPrices[flightClass];

        Booking newBooking = new Booking
        {
            FlightId = flightId,
            PassengerId = passengerId,
            Class = flightClass,
            Price = selectedClassPrice,
            BookingDate = DateTime.Now
        };

        _bookingDataProvider.AddBooking(newBooking);

        Console.WriteLine("Booking successful!");
    }

    public void CancelBooking(int bookingId)
    {
        Booking booking = _bookingDataProvider.GetBookingById(bookingId);
        if (booking == null)
        {
            Console.WriteLine("Booking not found.");
            return;
        }

        _bookingDataProvider.RemoveBooking(bookingId);

        Console.WriteLine("Booking canceled.");
    }

    public void ModifyBooking(int bookingId, FlightClass newFlightClass)
    {
        Booking booking = _bookingDataProvider.GetBookingById(bookingId);
        if (booking == null)
        {
            Console.WriteLine("Booking not found.");
            return;
        }

        Flight flight = _flightDataProvider.GetFlightById(booking.FlightId);
        if (flight == null)
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        if (!flight.ClassPrices.ContainsKey(newFlightClass))
        {
            Console.WriteLine("Invalid class selected.");
            return;
        }

        decimal newClassPrice = flight.ClassPrices[newFlightClass];
        booking.Class = newFlightClass;
        booking.Price = newClassPrice;

        _bookingDataProvider.UpdateBooking(bookingId, booking);

        Console.WriteLine("Booking modified.");
    }

    public List<Booking> GetPassengerBookings(int passengerId)
    {
        return _bookingDataProvider.GetBookingsForPassenger(passengerId);
    }
}
