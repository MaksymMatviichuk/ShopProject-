using ShopProject.Models;
using ShopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ініціалізація об'єкта DataStorage для збереження даних у файлі JSON
            DataStorage dataStorage = new DataStorage("shop_data.json");

            // Ініціалізація сервісу магазину з переданим списком продуктів
            List<Product> initialProducts = dataStorage.LoadFromJson<List<Product>>();
            ShopService shopService = new ShopService(initialProducts ?? new List<Product>());

            // Ініціалізація сервісу покупця
            CustomerService customerService = new CustomerService();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Show Products");
                Console.WriteLine("3. Buy Product");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Product Name: ");
                        string productName = Console.ReadLine();
                        Console.Write("Product Price: ");
                        decimal productPrice = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Product Quantity: ");
                        int productQuantity = Convert.ToInt32(Console.ReadLine());

                        // Check same name in shop
                        List<Product> existingProducts = shopService.GetAllProducts();
                        if (existingProducts != null)
                        {
                            Product existingProduct = existingProducts.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
                            if (existingProduct != null)
                            {
                                // Product exists, update quantity
                                existingProduct.Quantity += productQuantity;
                                Console.WriteLine($"Quantity of product \"{productName}\" updated.");
                            }
                            else
                            {
                                // If product not exists create new
                                Product newProduct = new Product(productName, productPrice, productQuantity);
                                shopService.AddProduct(newProduct);
                                Console.WriteLine("Product added.");
                            }

                            // Збереження продуктів у файл JSON
                            dataStorage.SaveToJson(shopService.GetAllProducts());
                        }

                        break;
                    case "2":
                        Console.WriteLine("List of Products:");
                        shopService.ShowProducts();
                        break;
                    case "3":
                        Console.Write("Your Name: ");
                        string customerName = Console.ReadLine();
                        Console.Write("Your money balance: ");
                        decimal money = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Product Name to Buy: ");
                        string productToBuyName = Console.ReadLine();

                        // Перевірка, чи існує продукт з такою назвою в магазині
                        Product productToBuy = shopService.GetAllProducts().FirstOrDefault(p => p.Name.Equals(productToBuyName, StringComparison.OrdinalIgnoreCase));

                        if (productToBuy != null)
                        {
                            Console.Write("Quantity to Buy: ");
                            int quantityToBuy = Convert.ToInt32(Console.ReadLine());

                            Customer customer = new Customer(customerName, quantityToBuy, money);

                            // Виконання покупки з урахуванням наявності продукту
                            customerService.Buy(shopService, productToBuy, customer);

                            // Збереження продуктів у файл JSON після купівлі
                            dataStorage.SaveToJson(shopService.GetAllProducts());
                        }
                        else
                        {
                            Console.WriteLine($"The product \"{productToBuyName}\" is not available in the shop.");
                        }
                        break;

                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select an option from the list.");
                        break;
                }
            }
        }
    }
}
