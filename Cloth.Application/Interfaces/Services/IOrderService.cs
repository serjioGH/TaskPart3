namespace Cloth.Application.Interfaces.Services;

using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Cloth.ClothUpdate;
using Cloth.Application.Models.Dto;
using Cloth.Domain.Entities;
using System.Threading.Tasks;

public interface IOrderService
{
    Task<ClothFilterDto> FilterOrdersAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight);

    Task<Cloth> CreateOrder(ClothCreateCommand command);

    Task<UpdateClothDto> UpdateOrderAsync(ClothUpdateCommand command);

    Task DeleteOrderAsync(Guid id);
}