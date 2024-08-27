using HikingGearShop.EmailService;
using HikingGearShop.OrderService.Data;
using HikingGearShop.ProductService.Data;
using HikingGearShop.ShoppingCartService.Data;
using Moq;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikingGearShop.Tests
{
    public class EmailServiceTests
    {
        private readonly IEmailService _emailService;
        private readonly Mock<IOrderRepository> _orderrepository;

        public EmailServiceTests()
        {
            _orderrepository = new Mock<IOrderRepository>();
            _emailService = new EmailService.EmailService(_orderrepository.Object);
        }

        [Fact]
        public void GenerateEmailContent_ShouldCreatePdfWithCorrectContent()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    OrderDate = DateTime.Now.AddDays(-10),
                    CustomerEmail = "test@customer.com",
                    TotalPrice = 100,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Name = "Product 1" }, Quantity = 1, Price = 50 },
                        new CartItem { Product = new Product { Name = "Product 2" }, Quantity = 1, Price = 50 }
                    }
                }
            };

            // Act
            var mailMessage = _emailService.GenerateEmailContent(orders, "test@customer.com");

            //Asserts
            Assert.NotNull(mailMessage);
            Assert.Equal("Monthly Order Summary", mailMessage.Subject);
            Assert.True(mailMessage.Attachments.Count == 1);
        }

        [Fact]
        public void SendMonthyOrdersEmail_ShouldSendEmailForEachCustomer()
        {
        }

        //[Fact]
        //public void TestSendEmail()
        //{
        //    var orders = new List<Order>
        //    {
        //        new Order
        //        {
        //            Id = 1,
        //            OrderDate = DateTime.Now.AddDays(-10),
        //            CustomerEmail = "test@customer.com",
        //            TotalPrice = 100,
        //            Items = new List<CartItem>
        //            {
        //                new CartItem { Product = new Product { Name = "Product 1" }, Quantity = 1, Price = 50 },
        //                new CartItem { Product = new Product { Name = "Product 2" }, Quantity = 1, Price = 50 }
        //            }
        //        }
        //    };

        //    // Act
        //    var mailMessage = _emailService.GenerateEmailContent(orders, "evkar91@gmail.com");
        //    _emailService.SendEmail(mailMessage);
        //}
    }
}
