using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSystem.Models
{
    class VIPSeat : Seat
    {
        public decimal PriceMultiplier { get; private set; }

        public VIPSeat(int row, int number, decimal priceMultiplier)
            : base(row, number)
        {
            PriceMultiplier = priceMultiplier;
        }
    }
}
