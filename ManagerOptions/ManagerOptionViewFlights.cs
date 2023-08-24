using AirportBooking.Interfaces;
using AirportBooking.Models;
namespace AirportBooking.ManagerOptions
{
    public class ManagerOptionViewFlights : IManagerOptions
    {
        public IFlightDataProvider _flightDataProvider;
        public ManagerOptionViewFlights(IFlightDataProvider flightDataProvider)
        {
            _flightDataProvider = flightDataProvider;
        }
        public void Execute()
        {
            List<Flight> flights = _flightDataProvider.GetAllFlights();
            flights.ForEach(flight => Console.WriteLine($"Flight ID: {flight.FlightId}, " +
                      $"Departure Country: {flight.DepartureCountry}, " +
                      $"Destination Country: {flight.DestinationCountry}, " +
                      $"Departure Date: {flight.DepartureDate}, " +
                      $"Departure Airport: {flight.DepartureAirport}, " +
                      $"Arrival Airport: {flight.ArrivalAirport}, " +
                      $"Class Prices: {string.Join(", ", flight.ClassPrices.Select(kv => $"{kv.Key}: {kv.Value}"))}"));
        }
    }
}