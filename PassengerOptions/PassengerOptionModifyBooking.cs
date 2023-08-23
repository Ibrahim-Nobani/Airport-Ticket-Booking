using AirportBooking.Interfaces;
using AirportBooking.Models;
namespace AirportBooking.PassengerOptions
{
    class PassengerOptionModifyBooking : IPassengerOptions
    {
        private IBookingService _bookingService;
        public PassengerOptionModifyBooking(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public void Execute()
        {
            Console.WriteLine("Enter the booking ID you would like to modify: ");
            int bookingId = int.Parse(Console.ReadLine());
            Console.Write("Enter the flight class: ");
            string input = Console.ReadLine();

            FlightClass classToBook;

            if (!Enum.TryParse(input, out classToBook))
            {
                Console.WriteLine("Invalid input.");
            }
            _bookingService.ModifyBooking(bookingId, FlightClass.FirstClass);
        }
    }
}