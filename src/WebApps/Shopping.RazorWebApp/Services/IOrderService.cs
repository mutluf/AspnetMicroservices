using Shopping.RazorWebApp.Models;

namespace Shopping.RazorWebApp.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
