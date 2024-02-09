using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Factories;
using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Commands.Order.OrderCreate;

public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand, CreateOrderDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderFactory _orderFactory;

    public OrderCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IOrderFactory orderFactory)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork;
        _orderFactory = orderFactory ?? throw new ArgumentNullException(nameof(orderFactory)); ;
    }

    public async Task<CreateOrderDto> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        var order = _orderFactory.CreateOrder(request);

        await _unitOfWork.Orders.Insert(order);
        _unitOfWork.Save();

        var checkedOrder = await _unitOfWork.Orders.GetById(order.Id);

        var orderDto = _mapper.Map<CreateOrderDto>(checkedOrder);

        return orderDto;
    }
}
