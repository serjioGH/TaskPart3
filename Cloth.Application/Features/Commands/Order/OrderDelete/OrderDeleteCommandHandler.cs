using Cloth.Application.Interfaces;
using Cloth.Domain.Exceptions;
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
        var order = await _unitOfWork.Orders.GetById(request.orderId);
        if (order == null)
        {
            throw new ItemNotFoundException($"Order with ID {request.orderId} not found.");
        }

        order.IsDeleted = true;
        _unitOfWork.Orders.Update(order);
        _unitOfWork.Save();
    }
}
