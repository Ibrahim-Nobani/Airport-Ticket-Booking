using AirportBooking.Interfaces;
using AirportBooking.Models;
namespace AirportBooking.Services
{
    public class FlightSearch : IFlightSearch
    {
        private readonly IFlightDataProvider _flightDataProvider;

        public FlightSearch(IFlightDataProvider flightDataProvider)
        {
            _flightDataProvider = flightDataProvider;
        }

        public List<Flight> SearchFlights(FlightFilterParameters parameters)
        {
            List<Flight> allFlights = _flightDataProvider.GetAllFlights();

            List<Flight> filteredFlights = allFlights;

            if (parameters.MaxPrice.HasValue)
            {
                filteredFlights = filteredFlights
                    .Where(f => f.ClassPrices.Values.Max() <= parameters.MaxPrice.Value)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(parameters.DepartureCountry))
            {
                filteredFlights = filteredFlights
                    .Where(f => f.DepartureCountry == parameters.DepartureCountry)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(parameters.DestinationCountry))
            {
                filteredFlights = filteredFlights
                    .Where(f => f.DestinationCountry == parameters.DestinationCountry)
                    .ToList();
            }

            if (parameters.DepartureDate.HasValue)
            {
                filteredFlights = filteredFlights
                    .Where(f => f.DepartureDate.Date == parameters.DepartureDate.Value.Date)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(parameters.DepartureAirport))
            {
                filteredFlights = filteredFlights
                    .Where(f => f.DepartureAirport == parameters.DepartureAirport)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(parameters.ArrivalAirport))
            {
                filteredFlights = filteredFlights
                    .Where(f => f.ArrivalAirport == parameters.ArrivalAirport)
                    .ToList();
            }

            if (parameters.Class.HasValue)
            {
                filteredFlights = filteredFlights
                    .Where(f => f.ClassPrices.ContainsKey(parameters.Class.Value))
                    .ToList();
            }

            return filteredFlights;
        }
    }
}