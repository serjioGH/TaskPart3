namespace Cloth.Application.Features.Commands.Order.OrderCreate;

using AutoMapper;
using Cloth.Domain.Exceptions;
using Domain.Entities;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;
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
        await DoIdenticalOrderLineExistAsync(order.OrderLines);
        await CheckClothSizesAsync(order);
        order.OrderLines = await CheckPricesAsync(order.OrderLines.ToList());
        order.TotalAmount = order.OrderLines.Sum(p => p.Price);
        await _unitOfWork.Orders.InsertAsync(order);

        var basket = await _unitOfWork.Baskets.GetBasketByUserIdAsync(request.UserId);
        await _unitOfWork.BasketLines.DeleteAll(basket.Id);
        await _unitOfWork.SaveAsync();

        var checkedOrder = await _unitOfWork.Orders.GetByIdAsync(order.Id);

        var orderDto = _mapper.Map<CreateOrderDto>(checkedOrder);

        return orderDto;
    }

    private async Task CheckClothSizesAsync(Order order)
    {
        foreach (var orderLine in order.OrderLines)
        {
            var clothSize = await _unitOfWork.ClothSizes
                .GetByCompositKey(orderLine.ClothId, orderLine.SizeId);

            if (clothSize != null)
            {
                clothSize.QuantityInStock -= orderLine.Quantity;

                if (clothSize.QuantityInStock < 0)
                {
                    throw new ItemNotFoundException($"Cloth does not have that quantity with specific size.");
                }
                else if (clothSize.QuantityInStock == 0)
                {
                    await _unitOfWork.ClothSizes.DeleteByCompositKey(clothSize.ClothId, clothSize.SizeId);
                }
                else
                {
                    await _unitOfWork.ClothSizes.UpdateAsync(clothSize);
                }
            }
        }
    }

    private async Task<List<OrderLines>> CheckPricesAsync(List<OrderLines> orderLines)
    {
        foreach (var orderLine in orderLines)
        {
            var product = await _unitOfWork.Cloths
                .GetClothById(orderLine.ClothId);

            orderLine.Price = product.Price * orderLine.Quantity;
        }

        return orderLines;
    }

    private async Task DoIdenticalOrderLineExistAsync(ICollection<OrderLines> orderLines)
    {
        var count = orderLines.GroupBy(p => new
        {
            p.ClothId,
            p.SizeId
        }).Count();

        if (count != orderLines.Count)
        {
            throw new Exception("Dublicated Orderlines.");
        }
    }
}