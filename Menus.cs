class Menu
{
    public void DisplayMainMenu()
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
                    DisplayPassengerMenu();
                    break;
                case 2:
                    DisplayManagerMenu();
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
    public static void DisplayPassengerMenu()
    {

        Console.WriteLine("Passenger Menu");
        Console.WriteLine("1. Search Flights");
        Console.WriteLine("2. Book Flight");
        Console.WriteLine("3. View Bookings");
        Console.WriteLine("4. Modify a Booking");
        Console.WriteLine("5. Cancel a Booking");
        Console.WriteLine("6. Go back to main menu");
        Console.Write("Enter your choice: ");
    }
    public static void DisplayManagerMenu()
    {
        throw new NotImplementedException();
    }
}