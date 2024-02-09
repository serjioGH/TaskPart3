using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Queries.Order.GetOrder;

public record GetOrderQuery(Guid OrderId) : IRequest<OrderDto>
{
    public GetOrderQuery() : this(Guid.Empty)
    {
    }
}
