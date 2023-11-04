using ProductShop.Application.Utilities;
using ProductShop.Domain.Entities.Products;
using ProductShop.Persistence.Dtos.Products;

namespace ProductShop.Services.Interfaces.Products;

public interface IProductService
{
    public Task<bool> CreateAsync(ProductCreateDto dto);

    public Task<bool> DeleteAsync(long productId);

    public Task<long> CountAsync();

    public Task<IList<Product>> GetAllAsync(PaginationParams @params);

    public Task<Product> GetByIdAsync(long productId);

    public Task<bool> UpdateAsync(long productId, ProductUpdateDto dto);

    public Task<bool> GetAllViewAsync(PaginationParams @params);
}
