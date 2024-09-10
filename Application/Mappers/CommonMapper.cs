using AutoMapper;
using Catalog.API.Application.Contract.Data;
using Catalog.API.Application.Dtos.Commons;

namespace Catalog.API.Application.Mappers;

public class CommonMapper : Profile
{
    public CommonMapper()
    {
        CreateMap<FilterDataDto, FilterData>();
        CreateMap<SearchDataDto, SearchData>();
    }
}
