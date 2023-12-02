using Shopping.RazorWebApp.Models;

namespace Shopping.RazorWebApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var response = await _client.GetAsync($"/order/{userName}");
            return await response.Content.ReadFromJsonAsync<List<OrderResponseModel>>();
        }
    }
}
