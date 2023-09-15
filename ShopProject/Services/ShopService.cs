using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Services
{
    public class ShopService
    {
        private List<Product> products = new List<Product>();

        public ShopService(List<Product> initialProducts)
        {
            products = initialProducts;
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void ShowProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public void SellProduct(Product product, Customer customer)
        {
            var availableProduct = products.FirstOrDefault(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));

            if (availableProduct != null && availableProduct.Quantity >= customer.QuantityToBuy)
            {
                availableProduct.Quantity -= customer.QuantityToBuy;
                Console.WriteLine($"Sold {customer.QuantityToBuy} {product.Name}(s) to {customer.Name}");
            }
            else
            {
                Console.WriteLine($"Not enough stock of {product.Name}");
            }
        }
    }
}
