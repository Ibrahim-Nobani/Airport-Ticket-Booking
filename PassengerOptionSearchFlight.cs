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
            // MaxPrice = 1500,
            DepartureCountry = "USA",
            DestinationCountry = "England"
        };

        List<Flight> searchResults = _flightSearchService.SearchFlights(searchParameters);

        Console.WriteLine("Search results:");
        searchResults.ForEach(flight => Console.WriteLine($"Flight {flight.FlightId}: {flight.DepartureAirport} to {flight.ArrivalAirport}"));
    }
}