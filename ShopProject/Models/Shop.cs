using ShopProject.Services;


namespace ShopProject.Models
{
    public class Shop
    {
        private ShopService shopService;

        public Shop(ShopService shopService)
        {
            this.shopService = shopService;
        }

        public void AddProduct(Product product)
        {
            shopService.AddProduct(product);
        }

        public void ShowProducts()
        {
            shopService.ShowProducts();
        }

        public void SellProduct(Product product, Customer customer)
        {
            shopService.SellProduct(product, customer);
        }
    }
}