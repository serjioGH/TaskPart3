using Cloth.Application.Features.Commands.Order.OrderCreate;
using Cloth.Application.Interfaces.Factories;
using Cloth.Domain.Entities;

namespace Cloth.Infrastructure.Factories;

public class OrderFactory : IOrderFactory
{
    public Order CreateOrder(OrderCreateCommand command)
    {
        Order order = new Order
        {
            StatusId = command.StatusId,
            PaymentId = command.PaymentId,
            UserId = command.UserId,
            TotalAmount = command.TotalAmount,
            OrderLines = command.OrderLines.Select(line => new OrderLines
            {
                SizeId = line.SizeId,
                Quantity = line.Quantity,
                ClothId = line.ClothId,
                OrderId = line.OrderId,
                Price = line.Price
            }).ToList(),
        };

        return order;
    }
}