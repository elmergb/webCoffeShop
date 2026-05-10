using final_crud.DTOs.Products;

namespace final_crud.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> Create(ProductDto dto);
        Task<ProductUpdateDto> Update(int id, ProductUpdateDto dto);
        //Task<bool> Delete(int id);
        //Task<ProductReadDto> GetById(int id);
        //Task<IEnumerable<ProductReadDto>> GetAll();
    }
}
