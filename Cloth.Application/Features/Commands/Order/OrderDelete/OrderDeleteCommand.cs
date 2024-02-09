using MediatR;

namespace Cloth.Application.Features.Commands.Order.OrderDelete;

public record OrderDeleteCommand(Guid orderId) : IRequest;
