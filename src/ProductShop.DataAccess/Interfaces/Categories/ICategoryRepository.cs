using ProductShop.DataAccess.Common;
using ProductShop.Domain.Entities.Categories;

namespace ProductShop.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>,
    IGetAll<Category>
{

}
