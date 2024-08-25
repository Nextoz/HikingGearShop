using HikingGearShop.ProductService.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikingGearShop.Tests
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductService> _productServiceMock;

        public ProductServiceTest()
        {
            _productServiceMock = new Mock<IProductService>();
        }

        //Det er derfor jeg skal have service med logik og repo kun til kommunikation med DB for at kunne mock den
        [Fact]
        public void GetProductsTest()
        {

            //_productServiceMock.GetProducts();
        }
    }
}
