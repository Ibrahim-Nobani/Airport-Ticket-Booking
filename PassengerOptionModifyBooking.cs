class PassengerOptionModifyBooking : IPassengerOptions
{
    private IBookingService _bookingService;
    public PassengerOptionModifyBooking(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    public void Execute()
    {
        _bookingService.ModifyBooking(3, FlightClass.FirstClass);
    }
}