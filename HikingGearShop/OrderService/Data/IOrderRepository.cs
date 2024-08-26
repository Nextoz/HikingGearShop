namespace HikingGearShop.OrderService.Data
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();

        IQueryable<Order> GetOrderForPreviousMonth(DateTime currentDate);

    }
}
