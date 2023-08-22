public class IdValidator
{
    private readonly IFlightDataProvider _dataProvider;

    public IdValidator(IFlightDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }
    public bool IdValidate(int flightId)
    {
        return IsFlightIdPositive(flightId) && IsFlightIdUnique(flightId);
    }

    public bool IsFlightIdUnique(int flightId)
    {
        var flights = _dataProvider.GetAllFlights();
        return !flights.Any(flight => flight.FlightId == flightId);
    }
    public bool IsFlightIdPositive(int flightId)
    {
        if (flightId < 0)
        {
            return false;
        }
        return true;
    }
}
