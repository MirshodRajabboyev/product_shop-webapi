using ProductShop.DataAccess.Common;
using ProductShop.DataAccess.ViewModels;
using ProductShop.Domain.Entities.Products;

namespace ProductShop.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>,
    IGetAll<Product>
{

}
