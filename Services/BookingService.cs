using AirportBooking.Interfaces;
using AirportBooking.Models;
namespace AirportBooking.Services
{
    public class BookingService : IBookingService
    {
        private IBookingDataProvider _bookingDataProvider;
        private IFlightDataProvider _flightDataProvider;

        public BookingService(IBookingDataProvider bookingDataProvider, IFlightDataProvider flightDataProvider)
        {
            _bookingDataProvider = bookingDataProvider;
            _flightDataProvider = flightDataProvider;
        }

        public bool BookFlight(int flightId, int passengerId, FlightClass flightClass)
        {
            Flight flight = _flightDataProvider.GetFlightById(flightId);
            if (flight == null)
            {
                Console.WriteLine("Flight not found.");
                return false;
            }

            if (!flight.ClassPrices.ContainsKey(flightClass))
            {
                Console.WriteLine("Invalid class selected.");
                return false;
            }

            decimal selectedClassPrice = flight.ClassPrices[flightClass];
            var idGenerator = new IDGenerator();

            Booking newBooking = new Booking
            {
                BookingId = idGenerator.generateId(),
                FlightId = flightId,
                PassengerId = passengerId,
                Class = flightClass,
                Price = selectedClassPrice,
                BookingDate = DateTime.Now
            };

            _bookingDataProvider.AddBooking(newBooking);
            return true;
        }

        public bool CancelBooking(int bookingId)
        {
            Booking booking = _bookingDataProvider.GetBookingById(bookingId);
            if (booking == null)
            {
                return false;
            }

            _bookingDataProvider.RemoveBooking(bookingId);

            return true;
        }

        public bool ModifyBooking(int bookingId, FlightClass newFlightClass)
        {
            Booking booking = _bookingDataProvider.GetBookingById(bookingId);
            if (booking == null)
            {
                return false;
            }

            Flight flight = _flightDataProvider.GetFlightById(booking.FlightId);
            if (flight == null)
            {
                return false;
            }

            if (!flight.ClassPrices.ContainsKey(newFlightClass))
            {
                return false;
            }

            decimal newClassPrice = flight.ClassPrices[newFlightClass];
            booking.Class = newFlightClass;
            booking.Price = newClassPrice;

            _bookingDataProvider.UpdateBooking(bookingId, booking);

            return true;
        }

        public List<Booking> GetPassengerBookings(int passengerId)
        {
            return _bookingDataProvider.GetBookingsForPassenger(passengerId);
        }
    }
}
