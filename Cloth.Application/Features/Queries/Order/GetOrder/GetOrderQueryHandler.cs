using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Queries.Order.GetOrder;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetOrderById(request.OrderId);

        var mappedOrder = _mapper.Map<OrderDto>(order);

        return mappedOrder;
    }
}
