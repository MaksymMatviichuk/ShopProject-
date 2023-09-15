using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopSystem.Models
{
    class DiscountProduct : Product
    {
        public decimal Discount { get; private set; }

        public DiscountProduct(int productId, string name, decimal price, decimal discount)
            : base(productId, name, price)
        {
            Discount = discount;
        }
    }
}
