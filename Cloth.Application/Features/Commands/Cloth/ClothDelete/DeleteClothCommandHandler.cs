using Cloth.Application.Interfaces;
using Cloth.Domain.Exceptions;
using MediatR;

namespace Cloth.Application.Features.Commands.Cloths.ClothDelete;

public class DeleteClothCommandHandler : IRequestHandler<DeleteClothCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClothCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteClothCommand command, CancellationToken cancellationToken)
    {
        var cloth = await _unitOfWork.Cloths.GetByIdAsync(command.clothId);

        if (cloth is null)
        {
            throw new ItemNotFoundException($"Cloth not found.");
        }

        cloth.IsDeleted = true;

        await _unitOfWork.Cloths.DeleteAsync(cloth);
        _unitOfWork.CommitTransaction();
    }
}