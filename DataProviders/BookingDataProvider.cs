using AirportBooking.Interfaces;
using AirportBooking.Models;
namespace AirportBooking.DataProviders
{
    public class BookingDataProvider : IBookingDataProvider
    {
        private List<Booking> _bookings;
        public BookingDataProvider()
        {
            _bookings = new List<Booking>();
        }
        public void AddBooking(Booking booking)
        {
            _bookings.Add(booking);
        }

        public void RemoveBooking(int bookingId)
        {
            _bookings.RemoveAll(booking => booking.BookingId == bookingId);
        }
        public Booking GetBookingById(int bookingId)
        {
            return _bookings.FirstOrDefault(booking => booking.BookingId == bookingId);
        }
        public List<Booking> GetBookingsForPassenger(int passengerId)
        {
            return _bookings.Where(booking => booking.PassengerId == passengerId).ToList();
        }
        public void UpdateBooking(int bookingId, Booking newBooking)
        {
            int index = _bookings.FindIndex(booking => booking.BookingId == bookingId);
            if (index != -1)
            {
                _bookings[index] = newBooking;
            }
        }
        public List<Booking> GetAllBookings()
        {
            return _bookings;
        }

    }
}