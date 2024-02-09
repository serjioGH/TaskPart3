using Cloth.Application.Models.Dto;
using Cloth.Domain.Entities;
using MediatR;

namespace Cloth.Application.Features.Commands.Order.OrderCreate;

public record OrderCreateCommand(Guid StatusId, Guid PaymentId, DateTime OrderDate, Guid UserId,
    decimal TotalAmount, List<OrderLineDto> OrderLines) : IRequest<CreateOrderDto>;
