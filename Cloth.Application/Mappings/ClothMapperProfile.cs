namespace Cloth.Application.Mappings;

using AutoMapper;
using Cloth.Application.Features.Commands.Basket.BasketLineCreate;
using Cloth.Application.Features.Commands.Basket.BasketLineUpdate;
using Cloth.Application.Features.Commands.Cloths.ClothCreate;
using Cloth.Application.Features.Commands.Order.OrderCreate;
using Cloth.Application.Models.Dto;
using Cloth.Application.Models.Dto.Basket;
using Cloth.Domain.Entities;

public class ClothMapperProfile : Profile
{
    public ClothMapperProfile()
    {
        FromTupleToClothDto();
        FromCommandEntityToDto();
        FromEntityToDto();
    }

    private void FromEntityToDto()
    {
        CreateMap<Cloth, ClothDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ClothGroups.Select(pg => pg.Group.Name).ToList()))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ClothSizes.Select(ps => new SizeDto
            {
                Size = ps.Size.Name.ToString(),
                QuantityInStock = ps.QuantityInStock,
                SizeId = ps.SizeId
            }).ToList()))
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ClothGroups.Select(ps => new GroupDto
            {
                Group = ps.Group.Name,
                GroupId = ps.GroupId
            })));

        CreateMap<Cloth, CreateClothDto>()
            .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ClothGroups.Select(pg => pg.Group.Name).ToList()))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ClothSizes.Select(ps => new SizeDto
            {
                Size = ps.Size.Name.ToString(),
                QuantityInStock = ps.QuantityInStock,
                SizeId = ps.SizeId
            }).ToList()))
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ClothGroups.Select(ps => new GroupDto
            {
                Group = ps.Group.Name,
                GroupId = ps.GroupId
            })));

        CreateMap<Cloth, UpdateClothDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ClothGroups.Any() ? src.ClothGroups.Select(pg => pg.Group.Name).ToList() : null))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ClothSizes.Any() ? src.ClothSizes.Select(ps => new SizeDto
            {
                Size = ps.Size.Name.ToString(),
                QuantityInStock = ps.QuantityInStock,
                SizeId = ps.SizeId
            }).ToList() : null))
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ClothGroups.Select(ps => new GroupDto
            {
                Group = ps.Group.Name,
                GroupId = ps.GroupId
            })));

        CreateMap<Order, OrderDto>()
           .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.CreatedOn))
           .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));

        CreateMap<Order, UpdateOrderDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));

        CreateMap<Order, CreateOrderDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));

        CreateMap<BasketLine, BasketLineCreateDto>()
            .ForMember(dest => dest.BasketLineId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BasketId, opt => opt.MapFrom(src => src.BasketId))
            .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.ClothId))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price * src.Quantity))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<BasketLine, BasketLineDto>()
            .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.ClothId))
            .ForMember(dest => dest.BasketId, opt => opt.MapFrom(src => src.BasketId))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId));

        CreateMap<BasketLine, BasketLineResponseDto>()
            .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.ClothId))
            .ForMember(dest => dest.BasketId, opt => opt.MapFrom(src => src.BasketId))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId));

        CreateMap<Basket, BasketDetailsDto>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
             .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
             .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.BasketLines.Sum(p => p.Quantity * p.Price)));

        CreateMap<BasketLine, BasketLineUpdateDto>()
            .ForMember(dest => dest.BasketLineId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BasketId, opt => opt.MapFrom(src => src.BasketId))
            .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.ClothId))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
    }

    private void FromCommandEntityToDto()
    {
        CreateMap<ClothCreateCommand, Cloth>()
            .ForMember(dest => dest.ClothSizes, opt => opt.MapFrom(src => src.Sizes))
            .ForMember(dest => dest.ClothGroups, opt => opt.MapFrom(src => src.Groups.Select(dto => new ClothGroup
            {
                GroupId = dto.GroupId
            }).ToList()));
        CreateMap<OrderCreateCommand, Order>()
            .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines.Select(dto => new OrderLines
            {
                SizeId = dto.SizeId,
                Quantity = dto.Quantity,
                ClothId = dto.ClothId
            }).ToList()));
        CreateMap<OrderLineCreateDto, OrderLines>()
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.ClothId))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId));

        CreateMap<GroupClothDto, ClothGroup>()
            .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId));

        CreateMap<SizeClothDto, ClothSize>()
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId))
            .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock));

        CreateMap<BasketLineCreateCommand, BasketLine>()
           .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.BasketLine.Quantity))
           .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.BasketLine.SizeId))
           .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.BasketLine.ClothId));

        CreateMap<BasketLineUpdateCommand, BasketLine>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BasketLineId))
           .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
           .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId))
           .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.ClothId));
    }

    private void FromTupleToClothDto()
    {
        CreateMap<(List<Cloth>? filteredProducts, List<string>? commonWords, List<string> sizes,
            decimal? lowestPrice, decimal? highestPrice), ClothFilterDto>()
            .ForMember(dest => dest.Cloths, act => act.MapFrom(src => src.filteredProducts))
            .ForMember(dest => dest.Filter, act => act.MapFrom(src => new FilterDto()
            {
                MaxPrice = src.highestPrice,
                MinPrice = src.lowestPrice,
                CommonWords = src.commonWords,
                Sizes = src.sizes,
            }));
    }
}