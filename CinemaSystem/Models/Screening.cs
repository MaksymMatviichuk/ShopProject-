using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSystem.Models
{
    class Screening
    {
        public Movie Movie { get; private set; }
        public DateTime DateTime { get; private set; }
        private List<Seat> Seats { get; set; }

        public Screening(Movie movie, DateTime dateTime, int numRows, int numSeatsPerRow)
        {
            Movie = movie;
            DateTime = dateTime;
            Seats = new List<Seat>();

            for (int row = 1; row <= numRows; row++)
            {
                for (int seatNumber = 1; seatNumber <= numSeatsPerRow; seatNumber++)
                {
                    Seats.Add(new Seat(row, seatNumber));
                }
            }
        }

        public void DisplayAvailableSeats()
        {
            Console.WriteLine($"Available seats for {Movie.Title} at {DateTime}:");
            foreach (var seat in Seats.Where(s => s.IsAvailable))
            {
                Console.WriteLine($"Row {seat.Row}, Seat {seat.Number}");
            }
        }

        public Seat GetSeat(int row, int number)
        {
            return Seats.FirstOrDefault(s => s.Row == row && s.Number == number);
        }
    }
}
