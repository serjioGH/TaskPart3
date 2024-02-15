namespace Cloth.Application.Features.Commands.Order.OrderCreate;

using AutoMapper;
using Domain.Entities;
using global::Cloth.Application.Interfaces;
using global::Cloth.Application.Models.Dto;
using MediatR;

public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand, CreateOrderDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public OrderCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateOrderDto> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request);

        await _unitOfWork.Orders.InsertAsync(order);

        var basket = await _unitOfWork.Baskets.GetBasketByUserIdAsync(request.UserId);
        await _unitOfWork.BasketLines.DeleteAll(basket.Id);
        _unitOfWork.Save();

        var checkedOrder = await _unitOfWork.Orders.GetByIdAsync(order.Id);

        var orderDto = _mapper.Map<CreateOrderDto>(checkedOrder);

        return orderDto;
    }
}