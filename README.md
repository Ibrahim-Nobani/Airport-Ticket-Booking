# Airport Ticket Booking System

## Introduction

Welcome to the Airport Ticket Booking System! This .NET console application enables passengers to book flights and empowers managers to efficiently manage bookings.

## Getting Started

1. Clone the repository:

   ```
   git clone https://github.com/Ibrahim-Nobani/Airport-Ticket-Booking.git
   ```

2. Navigate to the project directory:

   ```
   cd airport-ticket-booking
   ```

3. Build and run the application:

   ```
   dotnet build
   dotnet run
   ```

## Passenger Features

- **Book a Flight:** Easily book flights for desired destinations.
- **Choose Flight Class:** Select preferred class (Economy, Business, First Class) affecting flight prices.
- **Search Available Flights:** Search using parameters like price, country, date, airport, and class.
- **Cancel Booking:** Cancel booked flights.
- **Modify Booking:** Edit class and flight details.
- **View Bookings:** Check booking history.

## Manager Features

- **Filter Bookings:** Filter by flight, price, country, date, airport, passenger, and class.
- **Import Flights from CSV:** Import flights with model-level validations and clear error messages.
- **Dynamic Model Validation:** Get dynamic details about model validation for imported data fields.

## Project Structure

- **Passenger:** Manage passenger operations like booking, search, and modification.
- **Manager:** Handle functions such as filtering and CSV import.
- **Flight:** Represent flight information.
- **CSVValidator:** Validate CSV data against model constraints.

## Best Practices

We've followed C# best practices, ensuring code quality, organization, and documentation.

## Acknowledgements

Thanks to C# creators for providing the tools and practices that guided this project.

## License

This project is licensed under the [MIT License](LICENSE).