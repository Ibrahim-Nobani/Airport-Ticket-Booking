using AirportBooking.Models;
using AirportBooking.Interfaces;
namespace AirportBooking.PassengerOptions
{
    public class PassengerOptionDisplayPassengerBookings : IPassengerOptions
    {
        private IBookingService _bookingService;
        public PassengerOptionDisplayPassengerBookings(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter the passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());
            List<Booking> passengerBookings = _bookingService.GetPassengerBookings(passengerId);
            Console.WriteLine($"Passenger's bookings:");
            passengerBookings.ForEach(booking => Console.WriteLine($"Booking {booking.BookingId}: Flight {booking.FlightId}, Class: {booking.Class} {booking.Price}"));
        }
    }
}