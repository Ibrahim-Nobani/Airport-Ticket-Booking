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
            int bookingId = ReadInputHelper.GetIntInput("Enter the Booking ID: ");
            Console.Write("You can edit the flight class");
            FlightClass classToBook = ReadInputHelper.GetEnumInput<FlightClass>("Enter the flight class: ");
            bool isBookingModified = _bookingService.ModifyBooking(bookingId, classToBook);
            string modifyBookingResultMessage = isBookingModified ? "The Booking has been Modified!" : "Booking Modification Failed";
            Console.WriteLine($"{modifyBookingResultMessage}");
        }
    }
}