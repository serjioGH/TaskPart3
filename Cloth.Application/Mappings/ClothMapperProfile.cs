namespace Cloth.Application.Mappings;

using AutoMapper;
using Cloth.Application.Features.Commands.Basket.BasketLineCreate;
using Cloth.Application.Features.Commands.Basket.BasketLineUpdate;
using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Order.OrderCreate;
using Cloth.Application.Features.Queries.Cloths.GetCloths;
using Cloth.Application.Models.Dto;
using Cloth.Application.Models.Dto.Basket;
using Cloth.Domain.Entities;

public class ClothMapperProfile : Profile
{
    public ClothMapperProfile()
    {
        FromTupleToClothDto();
        FromCommandEntityToDto();
    }

    private void FromCommandEntityToDto()
    {
        CreateMap<ClothQuery, ClothListDto>();
        CreateMap<ClothCreateCommand, Cloth>()
            .ForMember(dest => dest.ClothSizes, opt => opt.MapFrom(src => src.Sizes.Select(dto => new ClothSize
            {
                SizeId = dto.SizeId,
                QuantityInStock = dto.Quantity
            }).ToList()))
            .ForMember(dest => dest.ClothGroups, opt => opt.MapFrom(src => src.Groups.Select(dto => new ClothGroup
            {
                GroupId = dto.GroupId
            }).ToList()));
        CreateMap<OrderCreateCommand, Order>()
            .ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines.Select(dto => new OrderLines
            {
                SizeId = dto.SizeId,
                Quantity = dto.Quantity,
                ClothId = dto.ClothId,
                OrderId = dto.OrderId,
                Price = dto.Price
            }).ToList()));
        CreateMap<Cloth, ClothDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ClothGroups.Select(pg => pg.Group.Name).ToList()))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ClothSizes.Select(ps => new SizeDto
            {
                QuantityInStock = ps.QuantityInStock,
                Name = ps.Size.Name
            }).ToList()));

        CreateMap<Cloth, CreateClothDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ClothGroups.Select(pg => pg.Group.Name).ToList()))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ClothSizes.Select(ps => new SizeDto
            {
                QuantityInStock = ps.QuantityInStock,
                Name = ps.Size.Name
            }).ToList()));

        CreateMap<Cloth, UpdateClothDto>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.ClothGroups.Any() ? src.ClothGroups.Select(pg => pg.Group.Name).ToList() : null))
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ClothSizes.Any() ? src.ClothSizes.Select(ps => new SizeDto
            {
                QuantityInStock = ps.QuantityInStock,
                Name = ps.Size.Name
            }).ToList() : null));

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));

        CreateMap<Order, UpdateOrderDto>()
            .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.PaymentId ?? Guid.Empty))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId ?? Guid.Empty))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));

        CreateMap<BasketLine, BasketLineCreateDto>();

        CreateMap<BasketLine, BasketLineDto>()
            .ForMember(
                 dest => dest.ClothName,
                 opt => opt.MapFrom(src => src.Cloth.Title))
             .ForMember(
                 dest => dest.SizeName,
                 opt => opt.MapFrom(src => src.Size.Name));

        CreateMap<Basket, BasketDetailsDto>()
             .ForMember(
                 dest => dest.Id,
                 opt => opt.MapFrom(src => src.Id))
             .ForMember(
                 dest => dest.UserId,
                 opt => opt.MapFrom(src => src.UserId))
             .ForMember(
                 dest => dest.FullName,
                 opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
             .ForMember(
                 dest => dest.TotalAmount,
                 opt => opt.MapFrom(src => src.BasketLines.Sum(p => p.Quantity * p.Price)));

        CreateMap<BasketLineCreateCommand, BasketLine>()
           .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.BasketLine.Quantity))
           .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.BasketLine.SizeId))
           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.BasketLine.Price))
           .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.BasketLine.ClothId));

        CreateMap<BasketLineUpdateCommand, BasketLine>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BasketLineId))
           .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
           .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId))
           .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.ClothId));

        CreateMap<BasketLine, BasketLineUpdateDto>()
            .ForMember(dest => dest.BasketLineId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BasketId, opt => opt.MapFrom(src => src.BasketId))
            .ForMember(dest => dest.ClothId, opt => opt.MapFrom(src => src.ClothId))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
    }

    private void FromTupleToClothDto()
    {
        CreateMap<(List<Cloth>? filteredProducts, List<string>? commonWords, List<string> sizes,
            decimal? lowestPrice, decimal? highestPrice), ClothFilterDto>()
            .ForMember(dest => dest.Products, act => act.MapFrom(src => src.filteredProducts))
            .ForMember(dest => dest.Filter, act => act.MapFrom(src => new FilterDto()
            {
                MaxPrice = src.highestPrice,
                MinPrice = src.lowestPrice,
                CommonWords = src.commonWords,
                Sizes = src.sizes,
            }));
    }
}