using ProductShop.Application.Exceptions.Products;
using ProductShop.Application.Utilities;
using ProductShop.DataAccess.Interfaces.Brands;
using ProductShop.DataAccess.Interfaces.Categories;
using ProductShop.DataAccess.Interfaces.Products;
using ProductShop.Domain.Entities.Brands;
using ProductShop.Domain.Entities.Products;
using ProductShop.Persistence.Dtos.Products;
using ProductShop.Persistence.Helpers;
using ProductShop.Services.Interfaces.Common;
using ProductShop.Services.Interfaces.Products;
using AutoMapper;

namespace ProductShop.Services.Services.Products;

public class ProductService : IProductService
{

    private readonly IProductRepository _repository;
    private readonly IBrandRepository _brandRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;

    public ProductService(IProductRepository productRepository,
       IPaginator paginator, 
       IBrandRepository brandRepository,
       ICategoryRepository categoryRepository,
       IMapper mapper)
    {
        this._repository = productRepository;
        this._paginator = paginator;
        this._brandRepository = brandRepository;
        this._mapper = mapper;
        this._categoryRepository = categoryRepository;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(ProductCreateDto dto)
    {
        Product product = _mapper.Map<Product>(dto);
        product.CreatedAt = product.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreateAsync(product);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long productId)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product == null) throw new ProductNotFoundException();

        var dbResult = await _repository.DeleteAsync(productId);

        return dbResult > 0;
    }

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        var products = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return products;
    }

    public Task<bool> GetAllViewAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetByIdAsync(long productId)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product == null) throw new ProductNotFoundException();
        else return product;
    }

    public async Task<bool> UpdateAsync(long productId, ProductUpdateDto dto)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product == null) throw new ProductNotFoundException();

        // update product with new items 
        product.CategoryId = dto.CategoryId;
        product.BrandId = dto.BrandId;
        product.Name = dto.Name;
        product.UnitPrice = dto.UnitPrice;
        product.Description = dto.Description;
        product.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(productId, product);

        return dbResult > 0;
    }
}
