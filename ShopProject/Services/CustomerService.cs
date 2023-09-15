using ShopProject.Interfaces;
using ShopProject.Models;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ShopProject.Services
//{
//    public class CustomerService : ICustomerService
//    {
        //public void Buy(ShopService shopService, Product product, Customer customer)
        //{
        //    shopService.SellProduct(product, customer);
        //}


namespace ShopProject.Services
    {
        public class CustomerService : ICustomerService
        {
            public void Buy(ShopService shopService, Product product, Customer customer)
            {
                Console.Write("Enter the quantity to buy: ");
                int quantityToBuy = Convert.ToInt32(Console.ReadLine());

                if (product is DiscountProduct discountProduct)
                {
                    // Обробка товарів зі знижкою
                    decimal totalPrice = discountProduct.Price * discountProduct.Discount * quantityToBuy;
                    if (discountProduct.Quantity >= quantityToBuy && customer.TryPurchase(totalPrice))
                    {
                        // Вираховуємо суму покупки і зменшуємо кількість товару в магазині
                        discountProduct.Quantity -= quantityToBuy;
                        Console.WriteLine($"Bought {quantityToBuy} {discountProduct.Name}(s) with discount for {totalPrice:C}.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough stock or funds to buy {quantityToBuy} {discountProduct.Name}(s) with discount.");
                    }
                }
                else if (product is Product regularProduct)
                {
                    // Обробка звичайних товарів
                    decimal totalPrice = regularProduct.Price * quantityToBuy;
                    if (regularProduct.Quantity >= quantityToBuy && customer.TryPurchase(totalPrice))
                    {
                        // Вираховуємо суму покупки і зменшуємо кількість товару в магазині
                        regularProduct.Quantity -= quantityToBuy;
                        Console.WriteLine($"Bought {quantityToBuy} {regularProduct.Name}(s) for {totalPrice:C}.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough stock or funds to buy {quantityToBuy} {regularProduct.Name}(s).");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product type.");
                }
            }
        }
    }
