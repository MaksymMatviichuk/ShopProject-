using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    class Hotel
    {
        private List<Room> rooms;
        private List<Reservation> reservations;

        public Hotel()
        {
            rooms = new List<Room>();
            reservations = new List<Reservation>();
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        public void MakeReservation(string guestName, int roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            Room room = rooms.Find(r => r.RoomNumber == roomNumber);
            if (room != null && room.IsAvailable)
            {
                Reservation reservation = new Reservation(guestName, room, checkInDate, checkOutDate);
                reservations.Add(reservation);
                room.Book();
                Console.WriteLine($"Reservation for {guestName} in Room {roomNumber} is confirmed.");
            }
            else
            {
                Console.WriteLine("Room not available for the selected dates.");
            }
        }

        public List<Room> CheckAvailability(DateTime checkInDate, DateTime checkOutDate)
        {
            List<Room> availableRooms = new List<Room>();
            foreach (var room in rooms)
            {
                if (IsRoomAvailable(room, checkInDate, checkOutDate))
                {
                    availableRooms.Add(room);
                }
            }
            return availableRooms;
        }

        public void CancelReservation(int reservationNumber)
        {
            Reservation reservation = reservations.Find(r => r.GetHashCode() == reservationNumber);
            if (reservation != null)
            {
                reservation.Room.CancelBooking();
                reservations.Remove(reservation);
                Console.WriteLine($"Reservation {reservationNumber} has been canceled.");
            }
            else
            {
                Console.WriteLine($"Reservation {reservationNumber} not found.");
            }
        }

        private bool IsRoomAvailable(Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            foreach (var reservation in reservations)
            {
                if (reservation.Room.RoomNumber == room.RoomNumber &&
                    (checkInDate >= reservation.CheckInDate && checkInDate < reservation.CheckOutDate) ||
                    (checkOutDate > reservation.CheckInDate && checkOutDate <= reservation.CheckOutDate))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
