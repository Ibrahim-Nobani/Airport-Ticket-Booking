public class PassengerOptionBookFlight : IPassengerOptions
{
    private IBookingService _bookingService;
    public PassengerOptionBookFlight(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    public void Execute()
    {
        Console.WriteLine("Enter the flight ID: ");
        int flightIdToBook= int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the passenger ID: ");
        int passengerId = int.Parse(Console.ReadLine());
        //int flightIdToBook = 1;
        FlightClass classToBook = FlightClass.Economy;
        //int passengerId = 1;
        _bookingService.BookFlight(flightIdToBook, passengerId, classToBook);
        _bookingService.BookFlight(flightIdToBook, passengerId, classToBook);
    }
}