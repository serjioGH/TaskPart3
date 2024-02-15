using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Commands.Order.OrderUpdate;

public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, UpdateOrderDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdateOrderDto> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetOrderById(request.Id);

        order.StatusId = request.StatusId;
        order.PaymentId = request.PaymentId;
        order.UserId = request.UserId;
        order.TotalAmount = request.TotalAmount;

        await _unitOfWork.Orders.UpdateAsync(order);
        _unitOfWork.Save();

        var updatedOrderDto = _mapper.Map<UpdateOrderDto>(order);
        return updatedOrderDto;
    }
}