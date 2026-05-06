using final_crud.DTOs.Products;

namespace final_crud.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> Create(ProductDto dto);
    }
}
