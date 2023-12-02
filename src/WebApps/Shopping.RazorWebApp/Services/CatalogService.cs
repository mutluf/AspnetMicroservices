using Shopping.RazorWebApp.Models;

namespace Shopping.RazorWebApp.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogsAsync()
        {
            var response = await _client.GetAsync("/catalog");
            return await response.Content.ReadFromJsonAsync<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalogAsync(string id)
        {
            var response = await _client.GetAsync($"/catalog/{id}");
            return await response.Content.ReadFromJsonAsync<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var response = await _client.GetAsync($"/catalog/{category}");
            return await response.Content.ReadFromJsonAsync<List<CatalogModel>>();
        }

        public async Task<CatalogModel> CreateCatalog(CatalogModel model)
        {
            var response = await _client.PostAsJsonAsync($"/catalog", model);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<CatalogModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
