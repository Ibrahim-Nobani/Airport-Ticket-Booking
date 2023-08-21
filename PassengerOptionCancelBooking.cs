class PassengerOptionCancelBooking : IPassengerOptions
{
    private IBookingService _bookingService;
    public PassengerOptionCancelBooking(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    public void Execute()
    {
        // provide the booking ID.
        _bookingService.CancelBooking(3);
    }
}