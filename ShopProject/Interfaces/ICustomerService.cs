using ShopProject.Models;
using ShopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Interfaces
{
    public interface ICustomerService
    {
        void Buy(ShopService shopService, Product product, Customer customer);
    }
}
