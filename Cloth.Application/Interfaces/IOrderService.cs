namespace Cloth.Application.Interfaces;

using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Features.Commands.Cloth.ClothUpdate;
using Cloth.Application.Models.Dto;
using System.Threading.Tasks;
using Cloth.Domain.Entities;

public interface IOrderService
{
    Task<ClothTask1Dto> FilterOrdersAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight);
    Task<Cloth> CreateOrder(ClothCreateCommand command);
    Task<UpdateClothDto> UpdateOrderAsync(ClothUpdateCommand command);

    Task DeleteOrderAsync(Guid id);
}

