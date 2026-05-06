using final_crud.Models.Products;

namespace final_crud.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProduct();
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product> getProduct(string name);
    }
}
