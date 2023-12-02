using Shopping.RazorWebApp.Entities;

namespace Shopping.RazorWebApp.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<Order> CheckOut(Order order);
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
