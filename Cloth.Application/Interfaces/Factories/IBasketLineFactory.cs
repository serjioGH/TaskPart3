namespace Cloth.Application.Interfaces.Factories;

using Cloth.Application.Features.Commands.Basket.BasketLineCreate;
using Cloth.Domain.Entities;

public interface IBasketLineFactory
{
    BasketLine CreateBasketLine(BasketLineCreateCommand command);
}