using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Queries.Order.GetOrders;

public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>>
{
    public DateTime? MinDate { get; set; }
    public DateTime? MaxDate { get; set; }
    public Guid UserId { get; set; }
    public Guid StatusId { get; set; }
}
