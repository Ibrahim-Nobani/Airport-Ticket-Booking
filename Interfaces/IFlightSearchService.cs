using AirportBooking.Models;
namespace AirportBooking.Interfaces
{
    public interface IFlightSearch
    {
        List<Flight> SearchFlights(FlightFilterParameters parameters);
    }
}