using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Interfaces
{
    public interface IShopService
    {
        void AddProduct(Product product);
        void ShowProducts();
        void SellProduct(Product product, Customer customer);
    }
}
