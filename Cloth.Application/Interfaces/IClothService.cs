namespace Cloth.Application.Interfaces;

using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Cloth.ClothUpdate;
using Cloth.Application.Models.Dto;
using System.Threading.Tasks;
using Cloth.Domain.Entities;

public interface IClothService
{
    Task<ClothTask1Dto> FilterClothsAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight);
    Task<Cloth> CreateCloth(ClothCreateCommand command);
    Task<Cloth> UpdateClothAsync(ClothUpdateCommand command);

    Task DeleteClothAsync(Guid id);
}

