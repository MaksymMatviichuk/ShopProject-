
using WebShopSystem.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string customerName = Console.ReadLine();
        Customer customer = new Customer(1, customerName);

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Product to Cart");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. Place Order");
            Console.WriteLine("4. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Product ID: ");
                    int productId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Product Name: ");
                    string productName = Console.ReadLine();
                    Console.Write("Enter Product Price: ");
                    decimal productPrice = decimal.Parse(Console.ReadLine());

                    Product product = new Product(productId, productName, productPrice);
                    customer.Cart.AddProduct(product);
                    Console.WriteLine($"{productName} added to the cart.");
                    break;

                case "2":
                    customer.Cart.DisplayCart();
                    break;

                case "3":
                    Console.WriteLine("Placing Order...");
                    customer.PlaceOrder();
                    break;

                case "4":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }
}
