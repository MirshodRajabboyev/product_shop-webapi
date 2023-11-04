using ProductShop.DataAccess.Interfaces.Brands;
using ProductShop.DataAccess.Interfaces.Categories;
using ProductShop.DataAccess.Interfaces.Products;
using ProductShop.DataAccess.Repositories.Brands;
using ProductShop.DataAccess.Repositories.Categories;
using ProductShop.DataAccess.Repositories.Products;

namespace ProductShop.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IBrandRepository, BrandRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
    }
}
