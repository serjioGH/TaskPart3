namespace Cloth.Application.Features.Commands.Basket.BasketLineCreate;

using Cloth.Application.Models.Dto.Basket;

using MediatR;
using System;

public record BasketLineCreateCommand(Guid UserId, BasketLineDto? BasketLine) : IRequest<BasketLineCreateDto>
{
}