using Microsoft.AspNetCore.Cors.Infrastructure;
using ProductShop.Services.Interfaces.Brands;
using ProductShop.Services.Interfaces.Categories;
using ProductShop.Services.Interfaces.Common;
using ProductShop.Services.Interfaces.Products;
using ProductShop.Services.Services.Brands;
using ProductShop.Services.Services.Categories;
using ProductShop.Services.Services.Common;
using ProductShop.Services.Services.Products;
using System.ComponentModel.Design;

namespace ProductShop.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddScoped<IBrandService, BrandService>();
        builder.Services.AddScoped<ICategoriesService, CategoryService>();
        builder.Services.AddScoped<IProductService, ProductService>();
    }
}
