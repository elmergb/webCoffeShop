namespace final_crud.Models.Products
{
    public class Product : BaseEntity
    {
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
 
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ProductType ProductType { get; set; }
    public string? Description { get; set; }
    public string? Material { get; set; }
    public string? ImageUrl { get; set; }
    public decimal? WeightGrams { get; set; }

    public Category Category { get; set; } = null!;
    //public Ring? Ring { get; set; }

    }
    public enum ProductType
    {
        Ring = 0,
        Necklace = 1,
        Bracelet = 2,
        Earring = 3,
        Other = 4,
    }
}
