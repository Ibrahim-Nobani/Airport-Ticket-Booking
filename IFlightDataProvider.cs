public interface IFlightDataProvider
{
    List<Flight> GetAllFlights();
    Flight GetFlightById(int flightId);
    void AddFlight(Flight flight);
    void UpdateFlight(int flightId, Flight updatedFlight);
    void RemoveFlight(int flightId);
}
