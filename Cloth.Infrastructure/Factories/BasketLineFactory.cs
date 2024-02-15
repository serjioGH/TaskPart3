namespace Cloth.Infrastructure.Factories;

using Cloth.Application.Features.Commands.Basket.BasketLineCreate;
using Cloth.Application.Interfaces.Factories;
using Cloth.Domain.Entities;

public class BasketLineFactory : IBasketLineFactory
{
    public BasketLine CreateBasketLine(BasketLineCreateCommand command)
    {
        BasketLine basketLine = new BasketLine
        {
            ClothId = command.BasketLine.ClothId,
            SizeId = command.BasketLine.SizeId,
            Quantity = command.BasketLine.Quantity,
            Price = command.BasketLine.Price
        };

        return basketLine;
    }
}