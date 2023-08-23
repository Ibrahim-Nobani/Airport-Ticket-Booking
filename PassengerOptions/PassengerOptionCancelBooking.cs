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
            Console.WriteLine("Enter the booking ID you would like to cancel: ");
            int bookingID = int.Parse(Console.ReadLine());
            // provide the booking ID.
            _bookingService.CancelBooking(bookingID);
        }
    }
}