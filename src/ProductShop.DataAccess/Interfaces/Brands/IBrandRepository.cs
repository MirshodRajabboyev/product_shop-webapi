using ProductShop.DataAccess.Common;
using ProductShop.Domain.Entities.Brands;

namespace ProductShop.DataAccess.Interfaces.Brands;

public interface IBrandRepository : IRepository<Brand, Brand>,
    IGetAll<Brand>
{

}
