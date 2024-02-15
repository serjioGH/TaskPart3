namespace Cloth.Application.Features.Commands.Basket.BasketLineDelete;

using MediatR;
using System;

public record BasketLineDeleteCommand(Guid basketLineId) : IRequest
{
}