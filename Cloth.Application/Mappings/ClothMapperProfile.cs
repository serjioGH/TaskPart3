namespace Cloth.Application.Mappings;

using AutoMapper;
using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Order.OrderCreate;
using Cloth.Application.Features.Queries.Cloths.GetCloths;
using Cloth.Application.Models.Dto;
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
        CreateMap<ClothCreateCommand, ClothDto>();
        CreateMap<OrderCreateCommand, CreateOrderDto>();
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
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));
    }

    private void FromTupleToClothDto()
    {
        CreateMap<(List<Cloth>? filteredProducts,List<string>? commonWords, List<string> sizes,
            decimal? lowestPrice, decimal? highestPrice), ClothTask1Dto> ()
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

