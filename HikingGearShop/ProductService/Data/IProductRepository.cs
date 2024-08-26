namespace HikingGearShop.ProductService.Data
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetProducts();
        Product GetProduct(string name);
        Product GetProduct(int id);
        
    }
}
