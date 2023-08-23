using AirportBooking.Interfaces;
using AirportBooking.Models;
namespace AirportBooking.PassengerOptions
{
    public class PassengerOptionBookFlight : IPassengerOptions
    {
        private IBookingService _bookingService;
        public PassengerOptionBookFlight(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public void Execute()
        {

            int flightIdToBook = ReadInputHelper.GetIntInput("Enter the flight ID: ");
            int passengerId = ReadInputHelper.GetIntInput("Enter the passenger ID: ");
            FlightClass classToBook = ReadInputHelper.GetEnumInput<FlightClass>("Enter the flight class: ");

            bool isBookingSuccessful = _bookingService.BookFlight(flightIdToBook, passengerId, classToBook);

            string bookingResultMessage = isBookingSuccessful ? "Booking successful" : "Booking failed";
            Console.WriteLine($"{bookingResultMessage}");
        }
    }
}