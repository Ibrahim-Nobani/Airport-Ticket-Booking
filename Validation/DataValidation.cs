using System.ComponentModel.DataAnnotations;
using AirportBooking.Interfaces;
using AirportBooking.Models;
namespace AirportBooking.Validation
{
    public class DataValidation
    {
        private readonly List<List<string>> _csvData;
        private readonly IFlightDataProvider _flightDataProvider;
        public DataValidation(List<List<string>> csvData, IFlightDataProvider flightDataProvider)
        {
            _csvData = csvData ?? throw new ArgumentNullException(nameof(csvData));
            _flightDataProvider = flightDataProvider;
        }
        public List<ValidationResult> ValidateCsv()
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            //List<List<string>> csvData = ParseCsv(csvText);

            foreach (List<string> fields in _csvData)
            {
                IdValidator idValidator = new IdValidator(_flightDataProvider);
                Flight flight = CreateFlightFromCsv(fields);
                var context = new ValidationContext(flight, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(flight, context, results, true) && idValidator.IdValidate(flight.FlightId);

                if (!isValid)
                {
                    validationResults.AddRange(results);
                    System.Console.WriteLine($"{flight.FlightId} is not valid!");
                }
                else
                {
                    _flightDataProvider.AddFlight(flight);
                }
            }
            validationResults.ForEach(validationResult => System.Console.WriteLine(validationResult.ErrorMessage));
            return validationResults;
        }
        private Flight CreateFlightFromCsv(List<string> fields)
        {
            Flight flight = new Flight
            {
                FlightId = Convert.ToInt32(fields[0]),
                DepartureCountry = fields[1],
                DestinationCountry = fields[2],
                DepartureDate = Convert.ToDateTime(fields[3]),
                DepartureAirport = fields[4],
                ArrivalAirport = fields[5],
                ClassPrices = new Dictionary<FlightClass, decimal>
        {
            { FlightClass.Economy, Convert.ToInt32(fields[6])},
            { FlightClass.Business, Convert.ToInt32(fields[7])},
            { FlightClass.FirstClass, Convert.ToInt32(fields[8])},
        }
            };
            System.Console.WriteLine($"{flight.FlightId}, {flight.ClassPrices.ElementAt(0).ToString()}");
            return flight;
        }

    }
}