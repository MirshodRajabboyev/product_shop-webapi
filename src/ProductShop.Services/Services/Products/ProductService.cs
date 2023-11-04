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
using ProductShop.Domain.Entities.Categories;
using ProductShop.DataAccess.ViewModels;

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
        Product product = new Product()
        {
            Name = dto.Name,
            CategoryId=dto.CategoryId,
            BrandId=dto.BrandId,
            UnitPrice=dto.UnitPrice,
            Description=dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };

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

    public async Task<IList<ProductViewModel>> GetAllViewAsync(PaginationParams @params)
    {


        var products = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        var brands = await _brandRepository.GetAllAsync(@params);
        var categories = await _categoryRepository.GetAllAsync(@params);

        List<ProductViewModel> productViewModels = new List<ProductViewModel>();

        for (int i = 0; i < products.Count; i++)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Id = products[i].Id;
            productViewModel.BrandId = products[i].BrandId;
            productViewModel.CategoryId = products[i].CategoryId;
            productViewModel.Name = products[i].Name;
            productViewModel.UnitPrice = products[i].UnitPrice;
            productViewModel.Description = products[i].Description;
            productViewModel.CreatedAt = products[i].CreatedAt;
            productViewModel.UpdatedAt = products[i].UpdatedAt;
            for (int j = 0; j < brands.Count; j++)
            {
                if (productViewModel.BrandId == brands[j].Id)
                {
                    productViewModel.BrandName = brands[j].Name;
                    break;
                }
            }
            for (int j = 0; j < categories.Count; j++)
            {
                if (productViewModel.CategoryId == categories[j].Id)
                {
                    productViewModel.CategoryName = categories[j].Name;
                    break;
                }
            }
            productViewModels.Add(productViewModel);
        }
        _paginator.Paginate(count, @params);

        return productViewModels;
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
