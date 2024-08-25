using HikingGearShop.OrderService.Data;

namespace HikingGearShop.OrderService.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
