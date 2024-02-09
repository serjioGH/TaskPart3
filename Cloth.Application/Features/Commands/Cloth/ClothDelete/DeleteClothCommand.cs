using MediatR;

namespace Cloth.Application.Features.Commands.Cloth.ClothDelete;

public record DeleteClothCommand(Guid clothId) : IRequest
{
}
