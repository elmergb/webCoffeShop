using final_crud.Services.Interfaces;
using final_crud.DTOs.Products;
using final_crud.Repositories.Interfaces;
using final_crud.Models.Products;

namespace final_crud.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductDto> Create(ProductDto dto)
        {
            var result = await _repository.getProduct(dto.Name);

            if (result != null)
                throw new Exception("Product with the same name already exists.");

            var product = new Product
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Price = dto.Price,
                ProductType = dto.ProductType,
                Description = dto.Description,
                Material = dto.Material,
                ImageUrl = dto.ImageUrl,
                WeightGrams = dto.WeightGrams
            };

            var resultProduct = await _repository.CreateProduct(product);

            return new ProductDto
            {
                CategoryId = resultProduct.CategoryId,
                Name = resultProduct.Name,
                Price = resultProduct.Price,
                ProductType = resultProduct.ProductType,
                Description = resultProduct.Description,
                Material = resultProduct.Material,
                ImageUrl = resultProduct.ImageUrl,
                WeightGrams = resultProduct.WeightGrams
            };
        }

        public async Task<ProductUpdateDto> Update(int id, ProductUpdateDto dto )
        {
            var product = await _repository.GetProductById(id);

            if (product == null)
                throw new Exception("product does not exist");

            product.CategoryId = dto.CategoryId;
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.ProductType = dto.ProductType;
            product.Description = dto.Description;
            product.Material = dto.Material;
            product.ImageUrl = dto.ImageUrl;
            product.WeightGrams = dto.WeightGrams;

            var resultProduct = await _repository.UpdateProduct(product);

            return new ProductUpdateDto
            {
                CategoryId = resultProduct.CategoryId,
            };
        } 
    }   
}
