using System;
using System.Collections.Generic;
using AirportBooking.DataProviders;
using AirportBooking.Interfaces;
using AirportBooking.Models;
using AirportBooking.ManagerOptions;
using AirportBooking.PassengerOptions;
using AirportBooking.Services;
using AirportBooking.Validation;
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

        DisplayMainMenu();

        void DisplayMainMenu()
        {
            while (true)
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
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice) || choice > (int)PassengerConsoleOption.Exit)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                var option = (PassengerConsoleOption)choice;
                if (option == PassengerConsoleOption.Exit)
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

                if (!int.TryParse(Console.ReadLine(), out choice) || choice > (int)ManagerConsoleOption.Exit)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                var option = (ManagerConsoleOption)choice;
                if (option == ManagerConsoleOption.Exit)
                {
                    Console.WriteLine("Exiting...");
                    return;
                }

                managerOptions[(int)option - 1].Execute();
                Console.WriteLine();
            }
        }
    }
    public enum PassengerConsoleOption
    {
        SearchAndDisplayFlights = 1,
        BookAndDisplayBooking = 2,
        DisplayBookings = 3,
        ModifyBooking = 4,
        CancelBooking = 5,
        Exit = 6
    }
    public enum ManagerConsoleOption
    {
        ParseFlightData = 1,
        FilterBooking = 2,
        ViewFlights = 3,
        Exit = 4
    }
}


