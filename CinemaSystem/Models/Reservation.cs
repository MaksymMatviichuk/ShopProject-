using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSystem.Models
{
    class Reservation
    {
        public Screening Screening { get; private set; }
        public Seat Seat { get; private set; }
        public string CustomerName { get; private set; }

        public Reservation(Screening screening, Seat seat, string customerName)
        {
            Screening = screening;
            Seat = seat;
            CustomerName = customerName;

            seat.Reserve(); 
        }
    }
}
