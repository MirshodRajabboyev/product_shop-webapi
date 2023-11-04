using AutoMapper;
using ProductShop.Domain.Entities.Categories;
using ProductShop.Domain.Entities.Products;
using ProductShop.Persistence.Dtos.Categories;
using ProductShop.Persistence.Dtos.Products;

namespace ProductShop.WebApi.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<CategoryCreateDto, Category>().ReverseMap();
        CreateMap<ProductCreateDto, Product>().ReverseMap();
    }
}