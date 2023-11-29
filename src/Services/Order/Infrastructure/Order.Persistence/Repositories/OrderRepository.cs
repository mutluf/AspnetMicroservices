using Microsoft.EntityFrameworkCore;
using Order.Application.Contracts.Persistence;
using Order.Persistence.Context;

namespace Order.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Domain.Entities.Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Domain.Entities.Order>> GetOrdersByUserNameAsync(string userName)
        {
            var orderList = await _dbContext.Orders
                                   .Where(o => o.UserName == userName)
                                   .ToListAsync();
            return orderList;
        }
    }
}
