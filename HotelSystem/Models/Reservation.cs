using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    class Reservation
    {
        public string GuestName { get; private set; }
        public Room Room { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }

        public Reservation(string guestName, Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            GuestName = guestName;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}
