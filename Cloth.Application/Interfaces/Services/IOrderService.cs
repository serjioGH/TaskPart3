namespace Cloth.Application.Interfaces.Services;

using Cloth.Application.Models.Dto;
using System.Threading.Tasks;

public interface IOrderService
{
    Task<ClothFilterDto> FilterOrdersAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight);
}