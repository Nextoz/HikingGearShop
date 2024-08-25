using HikingGearShop.ProductService.Data;

namespace HikingGearShop.ProductService.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(string name);
        void CreateProduct(Product product);
        //Task<Product> UpdateProduct(string name, Product product);
        Task DeleteProductAsync(int id);
    }
}
