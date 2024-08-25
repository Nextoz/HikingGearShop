using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikingGearShop.ProductService.Data;
using HikingGearShop.CommonDataAccess;
using HikingGearShop.ProductService.Services;

namespace HikingGearShop.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _productService.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Product>> GetProduct(string name)
        {
            return await _productService.GetProduct(name);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {

            if (id != product.Id)
            {
                return BadRequest();
            }

            _productService.CreateProduct(product);
            return Ok();    

            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProductExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

        }

        //// POST: api/Products
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        //}

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
           await _productService.DeleteProductAsync(id);
           return Ok(); 
            
        }

    }
}
