using Shopping.WebApp.Entities;

namespace Shopping.WebApp.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<Order> CheckOut(Order order);
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
