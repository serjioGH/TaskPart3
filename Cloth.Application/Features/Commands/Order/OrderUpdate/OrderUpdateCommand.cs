using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Commands.Order.OrderUpdate;

public record OrderUpdateCommand(Guid Id, Guid StatusId, Guid PaymentId, DateTime OrderDate, Guid UserId, decimal TotalAmount,
    List<OrderLineDto> OrderLines) : IRequest<UpdateOrderDto>;
