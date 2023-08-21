using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of data providers
        var flightDataProvider = new FlightDataProvider();
        var bookingDataProvider = new BookingDataProvider();

        // Create instances of services
        var flightSearchService = new FlightSearch(flightDataProvider);
        var bookingFilter = new BookingFilter(bookingDataProvider, flightDataProvider);
        var bookingService = new BookingService(bookingDataProvider, flightDataProvider);
        // Sample flight data
        var csvParser = new CsvParser();
        csvParser.ParseCsv(@".\Data.csv");
        var dataValidation = new DataValidation(csvParser.ParseCsv(@".\Data.csv"), flightDataProvider);
        dataValidation.ValidateCsv();
        IPassengerOptions passengerOptions = new PassengerOptionSearchFlight(flightSearchService);
        passengerOptions.Execute();
        var passengerOptions2 = new PassengerOptionBookFlight(bookingService);
        passengerOptions2.Execute();
        var p3 = new PassengerOptionDisplayPassengerBookings(bookingService);
        p3.Execute();


        //MainMenu();
        // Simulate interacting with the application's functionality
        //SearchAndDisplayFlights(flightSearchService);
        //BookAndDisplayBooking(bookingService);
        //DisplayBookings(bookingService);
        //ModifyBooking(bookingService);
        //CancelBooking(bookingService);
        FilterBooking(bookingFilter);
        void MainMenu()
        {
            Console.WriteLine("Welcome to the Airport Ticket Booking System!");
            Console.WriteLine("1. Passenger Menu");
            Console.WriteLine("2. Manager Menu");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    PassengerMenu();
                    break;
                case 2:
                    ManagerMenu();
                    break;
                case 3:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        void PassengerMenu()
        {
            while (true)
            {
                Console.WriteLine("Passenger Menu");
                Console.WriteLine("1. Search Flights");
                Console.WriteLine("2. Book Flight");
                Console.WriteLine("3. View Bookings");
                Console.WriteLine("4. Modify a Booking");
                Console.WriteLine("5. Cancel a Booking");
                Console.WriteLine("6. Go back to main menu");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SearchAndDisplayFlights(flightSearchService);
                        break;
                    case 2:
                        BookAndDisplayBooking(bookingService);
                        break;
                    case 3:
                        DisplayBookings(bookingService);
                        break;
                    case 4:
                        ModifyBooking(bookingService);
                        break;
                    case 5:
                        CancelBooking(bookingService);
                        break;
                    case 6:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        void ManagerMenu()
        {
            while (true)
            {
                Console.WriteLine("Manager Menu");
                Console.WriteLine("1. Add Flights (CSV)");
                Console.WriteLine("2. View Flights");
                Console.WriteLine("3. View Bookings");
                Console.WriteLine("4. Go back to main menu");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var csvParser = new CsvParser();
                        csvParser.ParseCsv(@".\Data.csv");
                        var dataValidation = new DataValidation(csvParser.ParseCsv(@".\Data.csv"), flightDataProvider);
                        dataValidation.ValidateCsv();
                        break;
                    case 2:
                        // Implement view flights logic here
                        break;
                    case 3:
                        // Implement view bookings logic here
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    static void SearchAndDisplayFlights(IFlightSearch flightSearchService)
    {
        // Simulate user input for search parameters
        var searchParameters = new FlightFilterParameters
        {
            // MaxPrice = 1500,
            DepartureCountry = "USA",
            DestinationCountry = "England"
        };

        // Search for flights based on the provided parameters
        List<Flight> searchResults = flightSearchService.SearchFlights(searchParameters);

        // Display search results
        Console.WriteLine("Search results:");
        searchResults.ForEach(flight => Console.WriteLine($"Flight {flight.FlightId}: {flight.DepartureAirport} to {flight.ArrivalAirport}"));
    }

    static void BookAndDisplayBooking(IBookingService bookingService)
    {
        // Simulate user input for booking
        int flightIdToBook = 1;
        FlightClass classToBook = FlightClass.Economy;
        string passengerName = "John Doe";
        int passengerId = 1;

        // Book the flight
        bool isBookingSuccessful = true;
        bookingService.BookFlight(flightIdToBook, passengerId, classToBook);

        // Display booking status
        if (isBookingSuccessful)
        {
            Console.WriteLine("Booking successful!");
        }
        else
        {
            Console.WriteLine("Booking failed. Please try again.");
        }

        // Display passenger's bookings
        List<Booking> passengerBookings = bookingService.GetPassengerBookings(passengerId);
        Console.WriteLine($"Passenger {passengerName}'s bookings:");
        passengerBookings.ForEach(booking => Console.WriteLine($"Booking {booking.BookingId}: Flight {booking.FlightId}, Class: {booking.Class} {booking.Price}"));
    }
    static void DisplayBookings(IBookingService bookingService)
    {
        int passengerId = 1;
        List<Booking> passengerBookings = bookingService.GetPassengerBookings(passengerId);
        Console.WriteLine($"Passenger's bookings:");
        passengerBookings.ForEach(booking => Console.WriteLine($"Booking {booking.BookingId}: Flight {booking.FlightId}, Class: {booking.Class} {booking.Price}"));
    }
    static void ModifyBooking(IBookingService bookingService)
    {
        bookingService.ModifyBooking(3, FlightClass.FirstClass);
        DisplayBookings(bookingService);
    }
    static void CancelBooking(IBookingService bookingService)
    {
        bookingService.CancelBooking(3);
        DisplayBookings(bookingService);
    }
    static void FilterBooking(IBookingFilter bookingFilter)
    {
        BookingFilterParameters filterParameters = new BookingFilterParameters
        {
            MinPrice = 100,
            FlightId = 1,
            ArrivalAirport = "LHR",
            DepartureAirport = "JFK"
        };
        List<Booking> filteredBookings = bookingFilter.FilterBookings(filterParameters);
        filteredBookings.ForEach(booking => Console.WriteLine($"FILTERED: Booking {booking.BookingId}: Flight {booking.FlightId}, Class: {booking.Class} {booking.Price}"));
    }
}
