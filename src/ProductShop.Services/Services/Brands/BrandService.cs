using ProductShop.Application.Exceptions.Brands;
using ProductShop.Application.Utilities;
using ProductShop.DataAccess.Interfaces.Brands;
using ProductShop.Domain.Entities.Brands;
using ProductShop.Persistence.Dtos.Brands;
using ProductShop.Persistence.Helpers;
using ProductShop.Services.Interfaces.Brands;
using ProductShop.Services.Interfaces.Common;

namespace ProductShop.Services.Services.Brands;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _repository;
    private readonly IPaginator _paginator;

    public BrandService(IBrandRepository brandRepository,
        IPaginator paginator)
    {
        this._repository = brandRepository;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreatAsync(BrandCreateDto dto)
    {
        Brand brand = new Brand()
        {
            Name = dto.Name,
        };

        var result = await _repository.CreateAsync(brand);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long brandId)
    {
        var brand = await _repository.GetByIdAsync(brandId);
        if (brand == null) throw new BrandNotFoundException();

        var dbResult = await _repository.DeleteAsync(brandId);

        return dbResult > 0;
    }

    public async Task<IList<Brand>> GetAllAsync(PaginationParams @params)
    {
        var brands = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return brands;
    }

    public async Task<Brand> GetByIdAsync(long brandId)
    {
        var brand = await _repository.GetByIdAsync(brandId);
        if (brand is null) throw new BrandNotFoundException();
        else return brand;
    }

    public async Task<bool> UpdateAsync(long brandId, BrandUpdateDto dto)
    {
        var brand = await _repository.GetByIdAsync(brandId);
        if (brand is null) throw new BrandNotFoundException();

        brand.Name = dto.Name;

        var dbResult = await _repository.UpdateAsync(brandId, brand);

        return dbResult > 0;
    }
}
