using final_crud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using final_crud.DTOs.Products;

namespace final_crud.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto dto)
        {
            var result = await _service.CreateCategoryAsync(dto);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _service.GetCategoryByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteId(int id)
        {
            var result = await _service.DeleteCategoryAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllCategoriesAsync();
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateDto dto)
        {
            var result = await _service.UpdateCategoryAsync(id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        } 
    }
}
