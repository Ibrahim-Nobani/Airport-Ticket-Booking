public class FlightDataProvider : IFlightDataProvider
{
    private List<Flight> _flights;

    public FlightDataProvider()
    {
        _flights = new List<Flight>();
    }

    public List<Flight> GetAllFlights()
    {
        return _flights;
    }

    public Flight GetFlightById(int flightId)
    {
        return _flights.FirstOrDefault(flight => flight.FlightId == flightId);
    }

    public void AddFlight(Flight flight)
    {
        _flights.Add(flight);
    }

    public void UpdateFlight(int flightId, Flight updatedFlight)
    {
        int index = _flights.FindIndex(flight => flight.FlightId == flightId);
        if (index != -1)
        {
            _flights[index] = updatedFlight;
        }
    }

    public void RemoveFlight(int flightId)
    {
        _flights.RemoveAll(flight => flight.FlightId == flightId);
    }
}
