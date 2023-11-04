using ProductShop.Application.Utilities;

namespace ProductShop.DataAccess.Common;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
