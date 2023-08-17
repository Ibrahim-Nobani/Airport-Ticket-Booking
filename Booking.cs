public class Booking
{
    public int BookingId { get; set; }
    public int FlightId { get; set; }
    public int PassengerId { get; set; }
    public FlightClass Class { get; set; } // Economy, Business, First Class
    public decimal Price { get; set; } // Calculated based on Flight and Class
    public DateTime BookingDate { get; set; }
}