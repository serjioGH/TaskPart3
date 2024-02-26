using Cloth.Application.Interfaces;
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
        var cloth = await _unitOfWork.Cloths.GetClothById(command.clothId);

        cloth.IsDeleted = true;

        await _unitOfWork.Cloths.UpdateAsync(cloth);
        await _unitOfWork.SaveAsync();
    }
}