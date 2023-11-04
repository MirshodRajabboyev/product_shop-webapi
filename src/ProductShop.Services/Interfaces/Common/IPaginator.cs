using ProductShop.Application.Utilities;

namespace ProductShop.Services.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long ItemsCount, PaginationParams @params);
}
