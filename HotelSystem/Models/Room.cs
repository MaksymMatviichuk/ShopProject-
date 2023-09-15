using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    class Room
    {
        public int RoomNumber { get; private set; }
        public int Capacity { get; private set; }
        public bool IsAvailable { get; private set; }
        public decimal PricePerNight { get; private set; }

        public Room(int roomNumber, int capacity, decimal pricePerNight)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
            IsAvailable = true;
            PricePerNight = pricePerNight;
        }

        public void Book()
        {
            IsAvailable = false;
        }

        public void CancelBooking()
        {
            IsAvailable = true;
        }
    }
}
