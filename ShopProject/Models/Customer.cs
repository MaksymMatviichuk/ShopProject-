using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Models
{
    public class Customer
    {
        public string Name { get; private set; }
        public decimal Wallet { get; private set; }
        public int QuantityToBuy { get; private set; }
        public Customer(string name, int quantityToBuy, decimal wallet)
        {
            Name = name;
            QuantityToBuy = quantityToBuy;
            Wallet = wallet;
        }

        public bool TryPurchase(decimal amount)
        {
            if (Wallet >= amount)
            {
                Wallet -= amount;
                return true;
            }
            return false;
        }

        public void Buy(Shop shop, Product product)
        {
            if (TryPurchase(product.Price * QuantityToBuy))
            {
                shop.SellProduct(product, this);
            }
            else
            {
                Console.WriteLine($"Not enough funds to buy {QuantityToBuy} {product.Name}(s).");
            }
        }
    }

}
