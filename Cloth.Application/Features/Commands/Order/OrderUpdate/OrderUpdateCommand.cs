using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Commands.Order.OrderUpdate;

public record OrderUpdateCommand(Guid Id, Guid StatusId, Guid PaymentId) : IRequest<UpdateOrderDto>;