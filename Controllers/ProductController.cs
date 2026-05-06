using final_crud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using final_crud.DTOs.Products;
using final_crud.Services;
namespace final_crud.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto dto)
        {
            try
            {
                var result = await _service.Create(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
