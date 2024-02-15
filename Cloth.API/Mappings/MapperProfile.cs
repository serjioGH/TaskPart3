namespace Cloth.API.Mappings;

using AutoMapper;
using Cloth.API.Models.Requests;
using Cloth.API.Models.Requests.Basket;
using Cloth.API.Models.Requests.Cloth;
using Cloth.API.Models.Requests.Order;
using Cloth.API.Models.Responses.Basket;
using Cloth.API.Models.Responses.Cloth;
using Cloth.API.Models.Responses.Order;
using Cloth.Application.Features.Commands.Basket.BasketLineCreate;
using Cloth.Application.Features.Commands.Basket.BasketLineUpdate;
using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Cloth.ClothUpdate;
using Cloth.Application.Features.Commands.Order.OrderCreate;
using Cloth.Application.Features.Commands.Order.OrderUpdate;
using Cloth.Application.Features.Queries.Cloths.GetCloths;
using Cloth.Application.Features.Queries.Order.GetOrders;
using Cloth.Application.Models.Dto;
using Cloth.Application.Models.Dto.Basket;

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
        CreateMap<OrderCreateRequest, OrderCreateCommand>();
        CreateMap<OrderUpdateRequest, OrderUpdateCommand>();
        CreateMap<BasketLineCreateRequest, BasketLineCreateCommand>();
        CreateMap<BasketLineUpdateRequest, BasketLineUpdateCommand>();
    }

    private void FromDtoToResponseMap()
    {
        CreateMap<ClothFilterDto, ClothResponseDto>();
        CreateMap<SizeClothRequest, SizeClothDto>();
        CreateMap<GroupClothRequest, GroupClothDto>();
        CreateMap<SizeDto, SizeClothRequest>();
        CreateMap<GroupDto, GroupClothRequest>();
        CreateMap<CreateClothDto, ClothCreateResponse>();
        CreateMap<UpdateClothDto, ClothUpdateResponse>();
        CreateMap<OrderDto, OrderResponse>().ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalAmount));
        CreateMap<CreateOrderDto, OrderCreateResponse>();
        CreateMap<UpdateOrderDto, OrderResponse>();
        CreateMap<OrderLineDto, OrderLineResponse>();
        CreateMap<BasketCreateDto, BasketCreateResponse>();
        CreateMap<BasketLineCreateDto, BasketLineResponse>();
        CreateMap<BasketLineUpdateDto, BasketLineUpdateResponse>();
        CreateMap<BasketDetailsDto, BasketResponse>();
    }
}