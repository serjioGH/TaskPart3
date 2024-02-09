namespace Cloth.API.Mappings;

using AutoMapper;
using Cloth.API.Models.Requests;
using Cloth.API.Models.Requests.Cloth;
using Cloth.API.Models.Requests.Order;
using Cloth.API.Models.Responses.Cloth;
using Cloth.API.Models.Responses.Order;
using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Cloth.ClothUpdate;
using Cloth.Application.Features.Queries.Cloths.GetCloths;
using Cloth.Application.Features.Queries.Order.GetOrders;
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
        CreateMap<ClothCreateRequest, ClothCreateCommand>();
        CreateMap<ClothUpdateRequest, ClothUpdateCommand>();
        CreateMap<OrderFilterRequest, GetOrdersQuery>();
    }

    private void FromDtoToResponseMap()
    {
        CreateMap<ClothTask1Dto, ClothResponseDto>();
        CreateMap<SizeClothRequest, SizeClothDto>();
        CreateMap<SizeDto, SizeClothRequest>();
        CreateMap<GroupClothRequest, GroupClothDto>();
        CreateMap<GroupDto, GroupClothRequest>();
        CreateMap<UpdateClothDto, ClothUpdateResponse>();
        CreateMap<OrderDto, OrderResponse>().ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalAmount));
    }

}

