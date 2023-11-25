using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext :ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("MongoSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("MongoSettings:CollectionName"));
        }

        public IMongoCollection<Product> Products { get; }
    }
}