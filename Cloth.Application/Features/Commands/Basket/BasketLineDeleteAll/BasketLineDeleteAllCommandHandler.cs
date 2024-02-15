namespace Cloth.Application.Features.Commands.Basket.BasketLineDeleteAll;

using global::Cloth.Application.Interfaces;
using global::Cloth.Domain.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class BasketLineDeleteAllCommandHandler : IRequestHandler<BasketLineDeleteAllCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public BasketLineDeleteAllCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task Handle(BasketLineDeleteAllCommand request, CancellationToken cancellationToken)
    {
        var basket = await _unitOfWork.Baskets.GetBasketByUserIdAsync(request.UserId);
        if (basket == null)
        {
            throw new ItemNotFoundException($"Basket for User: {request.UserId} not found.");
        }

        await _unitOfWork.BasketLines.DeleteAll(basket.Id);
        _unitOfWork.Save();
    }
}