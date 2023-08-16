using Product_Integration.Models;

namespace Product_Integration.Repo
{
    public interface IProduct
    {
        Task<IList<Product>> GetProducts();
        Task<Product> GetProductById(string id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);
    }
}
