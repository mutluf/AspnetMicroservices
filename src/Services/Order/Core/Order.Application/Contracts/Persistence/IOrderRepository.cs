
namespace Order.Application.Contracts.Persistence
{
    public interface IOrderRepository : IBaseRepository<Domain.Entities.Order>
    {
        Task<IEnumerable<Domain.Entities.Order>> GetOrdersByUserNameAsync(string userName);
    }
}
