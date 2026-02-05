using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class TypesContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            bool checkTypes = typeCollection.Find(b => true).Any();
            if (!checkTypes)
            {
                string path = Path.Combine("Data", "SeedData", "types.json");

                var typesData = File.ReadAllText(path);
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (productTypes != null)
                {
                    foreach (var item in productTypes)
                    {
                        typeCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }

}
