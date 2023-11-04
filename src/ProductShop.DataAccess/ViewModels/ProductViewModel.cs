using ProductShop.Domain.Entities;

namespace ProductShop.DataAccess.ViewModels;

public class ProductViewModel : Auditable
{
    public string Name { get; set; } = String.Empty;

    public long CategoryId { get; set; }

    public string CategoryName { get; set; } = String.Empty;

    public long BrandId { get; set; }

    public string BrandName { get; set; } = String.Empty;

    public double UnitPrice { get; set; }

    public string Description { get; set; } = String.Empty;
}
