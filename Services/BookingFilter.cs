using AirportBooking.Interfaces;
using AirportBooking.Models;
namespace AirportBooking.Services
{
    public class BookingFilter : IBookingFilter
    {
        private readonly IBookingDataProvider _bookingDataProvider;
        private readonly IFlightDataProvider _flightDataProvider;

        public BookingFilter(IBookingDataProvider bookingDataProvider, IFlightDataProvider flightDataProvider)
        {
            _bookingDataProvider = bookingDataProvider;
            _flightDataProvider = flightDataProvider;
        }

        public List<Booking> FilterBookings(BookingFilterParameters parameters)
        {
            List<Booking> allBookings = _bookingDataProvider.GetAllBookings();
            List<Flight> allFlights = _flightDataProvider.GetAllFlights();

            List<Booking> filteredBookings = allBookings;

            if (parameters.FlightId.HasValue)
            {
                filteredBookings = filteredBookings
                    .Where(booking => booking.FlightId == parameters.FlightId.Value)
                    .ToList();
            }

            if (parameters.MinPrice.HasValue)
            {
                filteredBookings = filteredBookings
                    .Where(booking => booking.Price >= parameters.MinPrice.Value)
                    .ToList();
            }
            if (!string.IsNullOrEmpty(parameters.DepartureAirport))
            {
                allFlights = allFlights.Where(flight => flight.DepartureAirport == parameters.DepartureAirport).ToList();

                filteredBookings = filteredBookings
                    .Where(booking => allFlights.Any(flight => booking.FlightId == flight.FlightId))
                    .ToList();
            }

            if (parameters.DepartureDate.HasValue)
            {
                allFlights = allFlights.Where(flight => flight.DepartureDate.Date == parameters.DepartureDate.Value.Date).ToList();

                filteredBookings = filteredBookings
                    .Where(booking => allFlights.Any(flight => booking.FlightId == flight.FlightId))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(parameters.DepartureCountry))
            {
                allFlights = allFlights.Where(flight => flight.DepartureCountry == parameters.DepartureCountry).ToList();

                filteredBookings = filteredBookings
                    .Where(booking => allFlights.Any(flight => booking.FlightId == flight.FlightId))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(parameters.DestinationCountry))
            {
                allFlights = allFlights.Where(flight => flight.DestinationCountry == parameters.DestinationCountry).ToList();

                filteredBookings = filteredBookings
                    .Where(booking => allFlights.Any(flight => booking.FlightId == flight.FlightId))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(parameters.ArrivalAirport))
            {
                allFlights = allFlights.Where(flight => flight.ArrivalAirport == parameters.ArrivalAirport).ToList();

                filteredBookings = filteredBookings
                    .Where(booking => allFlights.Any(flight => booking.FlightId == flight.FlightId))
                    .ToList();
            }
            if (parameters.PassengerId.HasValue)
            {
                filteredBookings = filteredBookings
                    .Where(booking => booking.PassengerId == parameters.PassengerId.Value)
                    .ToList();
            }

            if (parameters.Class.HasValue)
            {
                filteredBookings = filteredBookings
                    .Where(booking => booking.Class == parameters.Class.Value)
                    .ToList();
            }

            return filteredBookings;
        }
    }
}
