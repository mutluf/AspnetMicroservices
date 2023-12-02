﻿using Microsoft.EntityFrameworkCore;
using Shopping.WebApp.Data;
using Shopping.WebApp.Entities;
using Shopping.WebApp.Repositories.Abstractions;

namespace Shopping.WebApp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly ShoppingDbContext _dbContext;

        public OrderRepository(ShoppingDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Order> CheckOut(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                            .Where(o => o.UserName == userName)
                            .ToListAsync();

            return orderList;
        }
    }
}
