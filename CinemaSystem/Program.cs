using CinemaSystem.Models;
using System;

class Program
{
    static void Main(string[] args)
    {
        Movie movie = new Movie("Opengamer", 120, 12);
        Screening screening = new Screening(movie, DateTime.Now, numRows: 5, numSeatsPerRow: 10);

        Console.WriteLine($"Welcome to {movie.Title}!");

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Available Seats");
            Console.WriteLine("2. Reserve a Seat");
            Console.WriteLine("3. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    screening.DisplayAvailableSeats();
                    break;

                case "2":
                    Console.Write("Enter the row number: ");
                    int selectedRow = int.Parse(Console.ReadLine());

                    Console.Write("Enter the seat number: ");
                    int selectedSeatNumber = int.Parse(Console.ReadLine());

                    Seat selectedSeat = screening.GetSeat(selectedRow, selectedSeatNumber);

                    if (selectedSeat != null && selectedSeat.IsAvailable)
                    {
                        Console.Write("Enter your name: ");
                        string customerName = Console.ReadLine();

                        Reservation reservation = new Reservation(screening, selectedSeat, customerName);
                        Console.WriteLine($"Thank you, {customerName}, your seat is reserved!");
                        selectedSeat.IsAvailable = false; 
                    }
                    else
                    {
                        Console.WriteLine("Invalid seat selection. Please select an available seat.");
                    }
                    break;

                case "3":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
