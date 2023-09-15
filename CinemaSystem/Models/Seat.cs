using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSystem.Models
{
    class Seat
    {
        public int Row { get; private set; }
        public int Number { get; private set; }
        public bool IsAvailable { get; set; }

        public Seat(int row, int number)
        {
            Row = row;
            Number = number;
            IsAvailable = true;
        }

        public void Reserve()
        {
            IsAvailable = false;
        }
    }

}
