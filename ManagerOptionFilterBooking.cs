public class ManagerOptionFilterBooking : IManagerOptions
{
    private IBookingFilter _bookingFilter;
    public ManagerOptionFilterBooking(IBookingFilter bookingFilter)
    {
        _bookingFilter = bookingFilter;
    }
    public void Execute()
    {
        BookingFilterParameters filterParameters = new BookingFilterParameters
        {
            MinPrice = 100,
            FlightId = 1,
            ArrivalAirport = "LHR",
            DepartureAirport = "JFK"
        };
        List<Booking> filteredBookings = _bookingFilter.FilterBookings(filterParameters);
        filteredBookings.ForEach(booking => Console.WriteLine($"FILTERED: Booking {booking.BookingId}: Flight {booking.FlightId}, Class: {booking.Class} {booking.Price}"));
    }
}
