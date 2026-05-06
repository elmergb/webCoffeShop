using final_crud.DTOs.Products;

namespace final_crud.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryReadDto> GetCategoryByIdAsync(int id);
        Task<List<CategoryReadDto>> GetAllCategoriesAsync();
        Task<CategoryReadDto> CreateCategoryAsync(CategoryDto dto);
        Task<bool> UpdateCategoryAsync(int id, CategoryUpdateDto dto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
