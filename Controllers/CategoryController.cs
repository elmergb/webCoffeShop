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
        public async Task<IActionResult> AddCategory([FromBody]CategoryDto dto)
        {
            var result = await _service.CreateCategoryAsync(dto);

            return Ok(result);
        }
    }
}
