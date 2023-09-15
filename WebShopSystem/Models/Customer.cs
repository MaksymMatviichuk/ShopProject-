using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopSystem.Models
{
    class Customer
    {
        public int CustomerId { get; private set; }
        public string Name { get; private set; }
        public Cart Cart { get; private set; }

        public Customer(int customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
            Cart = new Cart();
        }

        public void PlaceOrder()
        {
            Console.WriteLine($"Customer: {Name}");
            Cart.DisplayCart();
            decimal total = Cart.CalculateTotal();
            Console.WriteLine($"Total: {total:C}");
        }
    }
}
