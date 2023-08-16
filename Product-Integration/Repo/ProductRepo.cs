using MongoDB.Driver;
using Product_Integration.Models;

namespace Product_Integration.Repo
{
    public class ProductRepo : IProduct
    {
        private IConfiguration _configuration;
        public ProductRepo(IConfiguration configuration) { _configuration = configuration; }
        private IMongoDatabase CreateNoSqlContext()
        {
            var client = new MongoClient(_configuration.GetSection("MongoDB").GetSection("DBConnectionString").Value);
            var database = client.GetDatabase(_configuration.GetSection("MongoDB").GetSection("DatabaseName").Value);
            return database;
        }


        public async Task<IList<Product>> GetProducts()
        {
            return await CreateNoSqlContext().GetCollection<Product>("PRODUCT").AsQueryable().ToListAsync();
        }
    }
}
