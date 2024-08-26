
using HikingGearShop.CommonDataAccess;

namespace HikingGearShop.OrderService.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDBContext _context;

        public OrderRepository(ShopDBContext context)
        {
            _context = context;
        }
        public IQueryable<Order> GetAll()
        {
            return _context.Orders;
        }

        public IQueryable<Order> GetOrderForPreviousMonth(DateTime currentDate)
        {
            return _context.Orders.Where(o => o.OrderDate > currentDate.AddMonths(-1));
        }
    }
}
