using Microsoft.Extensions.Logging;
using Order.Persistence.Context;

namespace Order.Persistence
{
    public class OrderContextDbSeed
    {
        public static async Task SeedAsync(OrderDbContext orderContext, ILogger<OrderContextDbSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();

                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContextDbSeed).Name);
            }
        }

        private static IEnumerable<Domain.Entities.Order> GetPreconfiguredOrders()
        {
            return new List<Domain.Entities.Order>
            {
                new Domain.Entities.Order() {UserName = "mutlu", FirstName = "Fatma", LastName = "Mutlu", EmailAddress = "fmutlu3002@gmail.com", AddressLine = "Bir yer", Country = "Turkey", TotalPrice = 921 }
            };
        }
    }
}
