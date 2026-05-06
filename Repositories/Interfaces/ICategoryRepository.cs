using final_crud.Models.Products;

namespace final_crud.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> GetAllCategory();
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
        Task<Category> GetCategory(string name);
    }
}
