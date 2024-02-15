using Cloth.Application.Interfaces;
using MediatR;

namespace Cloth.Application.Features.Commands.Order.OrderDelete;

public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderDeleteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetOrderById(request.orderId);

        order.IsDeleted = true;
        await _unitOfWork.Orders.UpdateAsync(order);
        _unitOfWork.Save();
    }
}