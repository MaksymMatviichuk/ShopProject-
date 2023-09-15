using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopSystem.Models
{
    class Cart
    {
        private List<Product> products = new List<Product>();

        // Add product to cart
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        //  Card Info
        public void DisplayCart()
        {
            Console.WriteLine("Cart Contents:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price:C}");
            }
        }

        // Total
        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }
            return total;
        }
    }
}
