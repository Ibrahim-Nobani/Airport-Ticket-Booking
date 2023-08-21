using System.ComponentModel.DataAnnotations;

public class Flight
{
    [Required(ErrorMessage = "Flight ID is Required.")]
   // [Unique(flightDataProvider, ErrorMessage = "Not Unique")]
    public int FlightId { get; set; }

    [Required(ErrorMessage = "Departure country is required.")]
    public string DepartureCountry { get; set; }

    [Required(ErrorMessage = "Destination country is required.")]
    public string DestinationCountry { get; set; }

    [Required(ErrorMessage = "Departure date is required.")]
    [DataType(DataType.DateTime)]
    //[FutureDate(ErrorMessage = "Departure date must be in the future.")]
    public DateTime DepartureDate { get; set; }

    [Required(ErrorMessage = "Departure airport is required.")]
    public string DepartureAirport { get; set; }

    [Required(ErrorMessage = "Arrival airport is required.")]
    public string ArrivalAirport { get; set; }

    public Dictionary<FlightClass, decimal> ClassPrices { get; set; } = new Dictionary<FlightClass, decimal>();
}
