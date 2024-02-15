namespace Cloth.Application.Features.Commands.Basket.BasketLineDeleteAll;

using MediatR;

public record BasketLineDeleteAllCommand(Guid UserId) : IRequest
{
}