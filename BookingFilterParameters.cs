public class BookingFilterParameters
{
    public int? FlightId { get; set; }
    public decimal? MinPrice { get; set; }
    public string DepartureCountry { get; set; }
    public string DestinationCountry { get; set; }
    public DateTime? DepartureDate { get; set; }
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public int? PassengerId { get; set; }
    public FlightClass? Class { get; set; }
}
