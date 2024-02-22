namespace Cloth.Application.Features.Commands.Basket.BasketLineDeleteAll;

using Cloth.Application.Interfaces;
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

        await _unitOfWork.BasketLines.DeleteAll(basket.Id);
        await _unitOfWork.SaveAsync();
    }
}