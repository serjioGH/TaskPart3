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
using Cloth.Application.Features.Commands.Cloths.ClothCreate;
using Cloth.Application.Features.Commands.Cloths.ClothUpdate;
using Cloth.Application.Features.Commands.Order.OrderCreate;
using Cloth.Application.Features.Commands.Order.OrderUpdate;
using Cloth.Application.Features.Queries.Cloth.GetCloth;
using Cloth.Application.Features.Queries.Cloths.GetCloths;
using Cloth.Application.Features.Queries.Order.GetOrders;
using Cloth.Application.Models.Dto;
using Cloth.Application.Models.Dto.Basket;
using Cloth.Domain.Entities;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        FromRequestToQueriesMap();
        FromDtoToResponseMap();
        FromRequestToCommandsMap();
    }

    private void FromRequestToQueriesMap()
    {
        CreateMap<ClothFilterRequest, ClothQuery>();
        CreateMap<ClothGetRequest, GetClothByIdQuery>();
        CreateMap<OrderFilterRequest, GetOrdersQuery>();
    }

    private void FromRequestToCommandsMap()
    {
        CreateMap<ClothCreateRequest, ClothCreateCommand>();
        CreateMap<ClothUpdateRequest, ClothUpdateCommand>();
        CreateMap<OrderLineCreateRequest, OrderLineCreateDto>();
        CreateMap<SizeClothRequest, SizeClothDto>();
        CreateMap<GroupClothRequest, GroupClothDto>();
        CreateMap<OrderCreateRequest, OrderCreateCommand>();
        CreateMap<OrderUpdateRequest, OrderUpdateCommand>();
        CreateMap<BasketLineCreateRequest, BasketLineCreateCommand>();
        CreateMap<BasketLineUpdateRequest, BasketLineUpdateCommand>();
    }

    private void FromDtoToResponseMap()
    {
        CreateMap<ClothFilterDto, ClothResponseDto>();
        CreateMap<ClothDto, ClothGetResponse>();
        CreateMap<Cloth, ClothDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name));
        CreateMap<SizeDto, SizeClothRequest>();
        CreateMap<GroupDto, GroupClothRequest>();
        CreateMap<CreateClothDto, ClothCreateResponse>();
        CreateMap<UpdateClothDto, ClothUpdateResponse>();
        CreateMap<OrderDto, OrderResponse>().ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalAmount));
        CreateMap<CreateOrderDto, OrderCreateResponse>();
        CreateMap<UpdateOrderDto, OrderUpdateResponse>();
        CreateMap<OrderLineDto, OrderLineResponse>();
        CreateMap<BasketCreateDto, BasketCreateResponse>();
        CreateMap<BasketLineCreateDto, BasketLineResponse>();
        CreateMap<BasketLineUpdateDto, BasketLineUpdateResponse>();
        CreateMap<BasketDetailsDto, BasketResponse>();
        CreateMap<GroupClothDto, GroupClothResponse>()
            .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId));
        CreateMap<GroupDto, GroupClothResponse>()
            .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId));
        CreateMap<SizeDto, SizeClothResponse>()
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId));
        CreateMap<SizeClothDto, SizeClothResponse>()
            .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId));
    }
}