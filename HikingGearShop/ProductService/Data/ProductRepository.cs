
using HikingGearShop.CommonDataAccess;
using Microsoft.EntityFrameworkCore;

namespace HikingGearShop.ProductService.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDBContext _context;

        public ProductRepository(ShopDBContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception();
            }
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        Product IProductRepository.GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IProductRepository.GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
