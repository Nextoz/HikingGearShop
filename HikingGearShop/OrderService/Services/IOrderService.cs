using HikingGearShop.OrderService.Data;

namespace HikingGearShop.OrderService.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int id);
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(int id, Order order);
        Task<Order> DeleteOrder(int id);
    }
}
