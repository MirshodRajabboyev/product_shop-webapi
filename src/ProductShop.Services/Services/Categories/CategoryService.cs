using ProductShop.Application.Exceptions.Categories;
using ProductShop.Application.Utilities;
using ProductShop.DataAccess.Interfaces.Categories;
using ProductShop.Domain.Entities.Brands;
using ProductShop.Domain.Entities.Categories;
using ProductShop.Persistence.Dtos.Categories;
using ProductShop.Persistence.Helpers;
using ProductShop.Services.Interfaces.Categories;
using ProductShop.Services.Interfaces.Common;

namespace ProductShop.Services.Services.Categories;

public class CategoryService : ICategoriesService
{

    private readonly ICategoryRepository _repository;
    private readonly IPaginator _paginator;

    public CategoryService(ICategoryRepository categoryRepository,
        IPaginator paginator)
    {
        this._repository = categoryRepository;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        Category category = new Category()
        {
            Name = dto.Name,
        };

        var result = await _repository.CreateAsync(category);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category == null) throw new CategoryNotFoundException();

        var dbResult = await _repository.DeleteAsync(categoryId);

        return dbResult > 0;
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var categories = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return categories;
    }

    public async Task<Category> GetByIdAsync(long cateogoryId)
    {
        var category = await _repository.GetByIdAsync(cateogoryId);
        if (category is null) throw new CategoryNotFoundException();
        else return category;
    }

    public async Task<bool> UpdateAsync(long cateogoryId, CategoryUpdateDto dto)
    {
        var category = await _repository.GetByIdAsync(cateogoryId);
        if (category is null) throw new CategoryNotFoundException();

        // update category with new items 
        category.Name = dto.Name;

        var dbResult = await _repository.UpdateAsync(cateogoryId, category);

        return dbResult > 0;
    }
}
