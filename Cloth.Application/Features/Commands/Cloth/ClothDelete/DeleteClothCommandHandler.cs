using Cloth.Application.Interfaces;
using Cloth.Domain.Exceptions;
using MediatR;

namespace Cloth.Application.Features.Commands.Cloth.ClothDelete;

public class DeleteClothCommandHandler : IRequestHandler<DeleteClothCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClothCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteClothCommand command, CancellationToken cancellationToken)
    {
        var cloth = await _unitOfWork.Cloths.GetById(command.clothId);
        if (cloth == null)
        {
            throw new ItemNotFoundException($"Cloth with ID {command.clothId} not found.");
        }

        cloth.IsDeleted = true;
        _unitOfWork.Cloths.Update(cloth);
        _unitOfWork.Save();
    }
}
