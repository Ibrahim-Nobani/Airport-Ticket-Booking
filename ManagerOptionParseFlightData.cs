public class ManagerOptionParseFlightData : IManagerOptions
{
    private IFlightDataProvider _flightDataProvider;
    public ManagerOptionParseFlightData(IFlightDataProvider flightDataProvider)
    {
        _flightDataProvider = flightDataProvider;
    }

    public void Execute()
    {
        var csvParser = new CsvParser();
        var dataValidation = new DataValidation(csvParser.ParseCsv(@".\Data.csv"), _flightDataProvider);
        dataValidation.ValidateCsv();
    }
}