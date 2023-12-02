using Shopping.RazorWebApp.Models;

namespace Shopping.RazorWebApp.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogModel>> GetCatalogsAsync();
        Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category);
        Task<CatalogModel> GetCatalogAsync(string id);
        Task<CatalogModel> CreateCatalog(CatalogModel model);
    }
}
