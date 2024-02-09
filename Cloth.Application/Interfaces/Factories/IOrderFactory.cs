using Cloth.Application.Features.Commands.Order.OrderCreate;
using Cloth.Domain.Entities;

namespace Cloth.Application.Interfaces.Factories;

public interface IOrderFactory
{
    Order CreateOrder(OrderCreateCommand command);
}
