namespace Cloth.Application.Features.Commands.Basket.BasketLineUpdate;

using Cloth.Application.Models.Dto.Basket;

using MediatR;

public record BasketLineUpdateCommand(Guid BasketLineId, Guid ClothId, Guid SizeId, int Quantity) : IRequest<BasketLineUpdateDto>
{
}