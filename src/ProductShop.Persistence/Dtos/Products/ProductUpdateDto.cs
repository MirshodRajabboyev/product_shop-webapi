namespace ProductShop.Persistence.Dtos.Products;

public class ProductUpdateDto
{
    public long CategoryId { get; set; }

    public long BrandId { get; set; }

    public string Name { get; set; } = String.Empty;

    public double UnitPrice { get; set; }

    public string Description { get; set; } = String.Empty;
}
