using HotelSystem.Models;

class Program
{
    static void Main(string[] args)
    {
        Hotel hotel = new Hotel();

        Room room1 = new Room(101, 2, 100);
        Room room2 = new Room(102, 3, 150);
        Room room3 = new Room(103, 1, 80);

        hotel.AddRoom(room1);
        hotel.AddRoom(room2);
        hotel.AddRoom(room3);

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nHotel Menu:");
            Console.WriteLine("1. Make Reservation");
            Console.WriteLine("2. Check Availability");
            Console.WriteLine("3. Cancel Reservation");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter guest name: ");
                    string guestName = Console.ReadLine();
                    Console.Write("Enter room number: ");
                    int roomNumber = int.Parse(Console.ReadLine());
                    Console.Write("Enter check-in date (yyyy-MM-dd): ");
                    DateTime checkInDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter check-out date (yyyy-MM-dd): ");
                    DateTime checkOutDate = DateTime.Parse(Console.ReadLine());
                    hotel.MakeReservation(guestName, roomNumber, checkInDate, checkOutDate);
                    break;

                case "2":
                    Console.Write("Enter check-in date (yyyy-MM-dd): ");
                    DateTime availableCheckInDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter check-out date (yyyy-MM-dd): ");
                    DateTime availableCheckOutDate = DateTime.Parse(Console.ReadLine());
                    List<Room> availableRooms = hotel.CheckAvailability(availableCheckInDate, availableCheckOutDate);
                    Console.WriteLine("Available Rooms:");
                    foreach (var availableRoom in availableRooms)
                    {
                        Console.WriteLine($"Room {availableRoom.RoomNumber} (Capacity: {availableRoom.Capacity}, Price: {availableRoom.PricePerNight:C})");
                    }
                    break;

                case "3":
                    Console.Write("Enter reservation number: ");
                    int reservationNumber = int.Parse(Console.ReadLine());
                    hotel.CancelReservation(reservationNumber);
                    break;

                case "4":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
