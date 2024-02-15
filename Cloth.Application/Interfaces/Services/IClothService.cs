namespace Cloth.Application.Interfaces.Services;

using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Cloth.ClothUpdate;
using Cloth.Application.Models.Dto;
using Cloth.Domain.Entities;
using System.Threading.Tasks;

public interface IClothService
{
    Task<ClothFilterDto> FilterClothsAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight);

    Task<Cloth> CreateCloth(ClothCreateCommand command);

    Task<Cloth> UpdateClothAsync(ClothUpdateCommand command);

    Task DeleteClothAsync(Guid id);
}