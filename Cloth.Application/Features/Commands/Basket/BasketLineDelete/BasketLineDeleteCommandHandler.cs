namespace Cloth.Application.Features.Commands.Basket.BasketLineDelete;

using Cloth.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class BasketLineDeleteCommandHandler : IRequestHandler<BasketLineDeleteCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public BasketLineDeleteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task Handle(BasketLineDeleteCommand request, CancellationToken cancellationToken)
    {
        var basketLine = await _unitOfWork.BasketLines.GetBasketLine(request.basketLineId);

        await _unitOfWork.BasketLines.DeleteAsync(basketLine.Id);
        await _unitOfWork.SaveAsync();
    }
}