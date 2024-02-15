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

        await _unitOfWork.Orders.InsertAsync(order);

        var basket = await _unitOfWork.Baskets.GetBasketByUserIdAsync(request.UserId);
        await _unitOfWork.BasketLines.DeleteAll(basket.Id);
        _unitOfWork.Save();

        var checkedOrder = await _unitOfWork.Orders.GetByIdAsync(order.Id);

        var orderDto = _mapper.Map<CreateOrderDto>(checkedOrder);

        return orderDto;
    }
}