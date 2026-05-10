using final_crud.Models.Products;

namespace final_crud.DTOs.Products
{
    public class ProductDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
        public string? Description { get; set; }
        public string? Material { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? WeightGrams { get; set; }
    }

    public class ProductUpdateDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
        public string? Description { get; set; }
        public string? Material { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public decimal? WeightGrams { get; set; }
    }

    public class ProductReadDto
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
        public string? Description { get; set; }
        public string? Material { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? WeightGrams { get; set; }
    }
}
