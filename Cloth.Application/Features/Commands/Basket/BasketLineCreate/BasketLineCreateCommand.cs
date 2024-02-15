namespace Cloth.Application.Features.Commands.Basket.BasketLineCreate;

using global::Cloth.Application.Models.Dto.Basket;

using MediatR;
using System;

public record BasketLineCreateCommand(Guid UserId, BasketLineDto? BasketLine) : IRequest<BasketLineCreateDto>
{
}