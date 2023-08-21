public class PassengerOptionBookFlight : IPassengerOptions
{
    private IBookingService _bookingService;
    public PassengerOptionBookFlight(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    public void Execute()
    {
        int flightIdToBook = 1;
        FlightClass classToBook = FlightClass.Economy;
        int passengerId = 1;
        _bookingService.BookFlight(flightIdToBook, passengerId, classToBook);
    }
}