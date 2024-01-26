namespace Cloth.Application.Interfaces;

using Cloth.Application.Models.Dto;
using System.Threading.Tasks;

public interface IClothService
{
    Task<ClothDto> FilterClothsAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight);
}

