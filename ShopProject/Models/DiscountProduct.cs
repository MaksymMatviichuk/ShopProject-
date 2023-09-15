using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Models
{
    public class DiscountProduct : Product
    {
        public decimal Discount { get; private set; }

        public DiscountProduct(string name, decimal price, int quantity, decimal discount)
            : base(name, price, quantity)
        {
            Discount = discount;
        }
    }

}
