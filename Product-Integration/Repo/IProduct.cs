using Product_Integration.Models;

namespace Product_Integration.Repo
{
    public interface IProduct
    {
        Task<IList<Product>> GetProducts();
    }
}
