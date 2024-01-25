namespace Cloth.API.Mappings;

using AutoMapper;
using Cloth.API.Models.Requests;
using Cloth.API.Models.Responses;
using Cloth.Application.Features.Queries.GetCloths;
using Cloth.Application.Models.Dto;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        FromRequestToQueriesMap();
        FromDtoToResponseMap();
    }

    private void FromRequestToQueriesMap()
    {
        CreateMap<ClothFilterRequest, ClothQuery>();
    }

    private void FromDtoToResponseMap()
    {
        CreateMap<ClothDto, ClothResponseDto>();
    }

}

