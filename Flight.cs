public class Flight
{
    public int FlightId { get; set; }
    public string DepartureCountry { get; set; }
    public string DestinationCountry { get; set; }
    public DateTime DepartureDate { get; set; }
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public Dictionary<FlightClass, decimal> ClassPrices { get; set; } = new Dictionary<FlightClass, decimal>();
}

