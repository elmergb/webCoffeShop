using final_crud.DTOs.Products;
using final_crud.Models.Products;
using final_crud.Repositories;
using final_crud.Repositories.Interfaces;
using final_crud.Services.Interfaces;


namespace final_crud.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryReadDto> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetCategoryById(id);

            if (category == null)
            {
                throw new Exception($"Category with ID {id} not found.");
            }

            return new CategoryReadDto
            {
                Name = category.Name,
                Description = category.Description,
                ParentCategoryId = category.ParentCategoryId,

                SubCategories = category.SubCategories?
                    .Select(sub => new CategoryReadDto
                    {
                        Name = sub.Name,
                        Description = sub.Description,
                        ParentCategoryId = sub.ParentCategoryId,
                        SubCategories = null
                    })
                    .ToList()
            };
        }

        public async Task<List<CategoryReadDto>> GetAllCategoriesAsync()
        {
            var categories = await _repository.GetAllCategory();

            var list = categories.Select(c => new CategoryReadDto
            {
                Name = c.Name,
                Description = c.Description,
                ParentCategoryId = c.ParentCategoryId,
            }).ToList();

            return list;
        }

        public async Task<CategoryReadDto> CreateCategoryAsync(CategoryDto dto)
        {
            var isExist = await _repository.GetCategory(dto.Name);

            if (isExist != null)
                throw new Exception("Category already exist");

            var Category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                ParentCategoryId = dto.ParentCategoryId,
            };

            var createdCategory = await _repository.CreateCategory(Category);

            return new CategoryReadDto
            {
                Name = createdCategory.Name,
                Description = createdCategory.Description,
                ParentCategoryId = createdCategory.ParentCategoryId,
            };
        }

        public async Task<CategoryReadDto> UpdateCategoryAsync(int id, CategoryUpdateDto dto)
        {
            var isExist = await _repository.GetCategoryById(id);

            if (isExist == null)
                throw new Exception("Category not found");

            isExist.Name = dto.Name;
            isExist.Description = dto.Description;
            isExist.ParentCategoryId = dto.ParentCategoryId;

            await _repository.UpdateCategory(isExist);

            return new CategoryReadDto
            {
                Name = isExist.Name,
                Description = dto.Description,
                ParentCategoryId = dto.ParentCategoryId,
            };
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var isExist = await _repository.GetCategoryById(id);
            if (isExist == null)
                throw new Exception("Category not found");
            return await _repository.DeleteCategory(id);
        }
    }
}
