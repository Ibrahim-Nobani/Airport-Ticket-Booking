using AirportBooking.Interfaces;
using AirportBooking.Models;
namespace AirportBooking.PassengerOptions
{
    public class PassengerOptionSearchFlight : IPassengerOptions
    {
        private IFlightSearch _flightSearchService;
        public PassengerOptionSearchFlight(IFlightSearch flightSearchService)
        {
            _flightSearchService = flightSearchService;
        }
        public void Execute()
        {
            var searchParameters = new FlightFilterParameters
            {
                DepartureCountry = "USA",
                DestinationCountry = "England"
            };

            List<Flight> searchResults = _flightSearchService.SearchFlights(searchParameters);

            Console.WriteLine("Search results:");
            searchResults.ForEach(flight => Console.WriteLine($"Flight {flight.FlightId}: {flight.DepartureAirport} to {flight.ArrivalAirport}"));
        }
    }
}