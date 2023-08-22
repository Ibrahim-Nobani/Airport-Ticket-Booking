using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var flightDataProvider = new FlightDataProvider();
        var bookingDataProvider = new BookingDataProvider();

        var flightSearchService = new FlightSearch(flightDataProvider);
        var bookingFilter = new BookingFilter(bookingDataProvider, flightDataProvider);

        var bookingService = new BookingService(bookingDataProvider, flightDataProvider);

        IPassengerOptions[] passengerOptions = new IPassengerOptions[]
            {
                new PassengerOptionSearchFlight(flightSearchService),
                new PassengerOptionBookFlight(bookingService),
                new PassengerOptionDisplayPassengerBookings(bookingService),
                new PassengerOptionModifyBooking(bookingService),
                new PassengerOptionCancelBooking(bookingService)
            };
        IManagerOptions[] managerOptions = new IManagerOptions[]
            {
                new ManagerOptionParseFlightData(flightDataProvider),
                new ManagerOptionFilterBooking(bookingFilter),
                new ManagerOptionViewFlights(flightDataProvider),
            };
        ManagerMenu();
        PassengerMenu();

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
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice) || choice > (int)ConsoleOption.Exit)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                var option = (ConsoleOption)choice;
                if (option == ConsoleOption.Exit)
                {
                    Console.WriteLine("Exiting...");
                    return;
                }
                System.Console.WriteLine($"Option {(int)option}");
                passengerOptions[(int)option - 1].Execute();
                Console.WriteLine();
            }
        }
        void ManagerMenu()
        {
            while (true)
            {
                Console.WriteLine("Manager Menu");
                Console.WriteLine("1. Parse Flight Data");
                Console.WriteLine("2. Filter Booking");
                Console.WriteLine("3. View Flights");
                Console.WriteLine("4. Go back to main menu");
                Console.Write("Enter your choice: ");
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice) || choice > (int)ManagerOption.Exit)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                var option = (ManagerOption)choice;
                if (option == ManagerOption.Exit)
                {
                    Console.WriteLine("Exiting...");
                    return;
                }

                managerOptions[(int)option - 1].Execute();
                Console.WriteLine();
            }
        }
    }
    public enum ConsoleOption
    {
        SearchAndDisplayFlights = 1,
        BookAndDisplayBooking = 2,
        DisplayBookings = 3,
        ModifyBooking = 4,
        CancelBooking = 5,
        Exit = 6
    }
    public enum ManagerOption
    {
        ParseFlightData = 1,
        FilterBooking = 2,
        ViewFlights = 3,
        Exit = 4
    }
}


