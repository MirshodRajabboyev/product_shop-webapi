using ProductShop.Application.Utilities;
using ProductShop.Domain.Entities.Brands;
using ProductShop.Persistence.Dtos.Brands;

namespace ProductShop.Services.Interfaces.Brands;

public interface IBrandService
{
    public Task<bool> CreatAsync(BrandCreateDto dto);

    public Task<bool> DeleteAsync(long brandId);

    public Task<long> CountAsync();

    public Task<IList<Brand>> GetAllAsync(PaginationParams @params);

    public Task<Brand> GetByIdAsync(long brandId);

    public Task<bool> UpdateAsync(long brandId, BrandUpdateDto dto);
}
