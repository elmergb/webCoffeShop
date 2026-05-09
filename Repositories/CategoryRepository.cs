using final_crud.Repositories.Interfaces;
using final_crud.Services.Interfaces;
using final_crud.Data;
using final_crud.Models.Products;
using Microsoft.EntityFrameworkCore;
namespace final_crud.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories
                .Include(c => c.ParentCategory)  
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _context.Categories
                .Include(c => c.ParentCategory)     
                .Include(c => c.SubCategories)
                .ToListAsync();
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category> GetCategory(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
