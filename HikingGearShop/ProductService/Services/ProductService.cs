using HikingGearShop.CommonDataAccess;
using HikingGearShop.ProductService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HikingGearShop.ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly ShopDBContext _context;

        public ProductService(ShopDBContext context)
        {
            _context = context;
        }

        public Task<List<Product>> GetProducts()
        {
            return _context.Products.ToListAsync();
        }
        public void CreateProduct(Product product)
        {
            
            _context.Products.Add(product);
            _context.SaveChanges();

        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Product> GetProduct(string name)
        {
            var product = _context.Products.FirstOrDefaultAsync(p => p.Name == name);
            if (product == null)
            {
                //Skal lige finde ud af hvad der skal ske her, fordi er det her hvor man kan søge?
                throw new Exception(); 
            }
            return product;
        }

    }
}
