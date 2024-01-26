namespace Cloth.Application.Mappings;

using AutoMapper;
using Cloth.Application.Models.Dto;
using Cloth.Domain.Entities;

public class ClothMapperProfile : Profile
{
    public ClothMapperProfile()
    {
        FromTupleToClothDto();
    }

    private void FromTupleToClothDto()
    {
        CreateMap<(List<Cloth>? filteredProducts,List<string>? commonWords, List<string> sizes,
            decimal? lowestPrice, decimal? highestPrice), ClothDto> ()
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

