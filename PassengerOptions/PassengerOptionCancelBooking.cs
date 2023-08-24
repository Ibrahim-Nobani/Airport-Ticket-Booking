using AirportBooking.Interfaces;
namespace AirportBooking.PassengerOptions
{
    public class PassengerOptionCancelBooking : IPassengerOptions
    {
        private IBookingService _bookingService;
        public PassengerOptionCancelBooking(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public void Execute()
        {
            int bookingID = ReadInputHelper.GetIntInput("Enter the Booking ID: ");
            bool isBookingCancelled = _bookingService.CancelBooking(bookingID);
            string cancelBookingResultMessage = isBookingCancelled ? "The Booking has been canceled" : "Booking Cancellation Failed, Booking does not exist!";
            Console.WriteLine($"{cancelBookingResultMessage}");
        }
    }
}