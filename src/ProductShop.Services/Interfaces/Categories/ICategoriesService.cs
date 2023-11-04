using ProductShop.Application.Utilities;
using ProductShop.Domain.Entities.Categories;
using ProductShop.Persistence.Dtos.Categories;

namespace ProductShop.Services.Interfaces.Categories;

public interface ICategoriesService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<long> CountAsync();

    public Task<IList<Category>> GetAllAsync(PaginationParams @params);

    public Task<Category> GetByIdAsync(long cateogoryId);

    public Task<bool> UpdateAsync(long cateogoryId, CategoryUpdateDto dto);
}
