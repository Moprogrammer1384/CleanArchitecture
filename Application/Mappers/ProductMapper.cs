using AutoMapper;
using Catalog.API.Application.Dtos.Products;
using Catalog.API.Models;

namespace Catalog.API.Application.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ProductForAddDto, Product>();
        CreateMap<ProductForUpdateDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}
