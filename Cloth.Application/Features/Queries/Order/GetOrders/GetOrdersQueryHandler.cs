using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Queries.Order.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetOrdersQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.Orders.FilterOrdersAsync(request.MinDate, request.MaxDate, request.UserId, request.StatusId);
        var mappedOrders = _mapper.Map<IEnumerable<OrderDto>>(orders);
        return mappedOrders;
    }
}
