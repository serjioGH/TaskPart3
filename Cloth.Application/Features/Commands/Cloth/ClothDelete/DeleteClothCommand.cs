using MediatR;

namespace Cloth.Application.Features.Commands.Cloths.ClothDelete;

public record DeleteClothCommand(Guid clothId) : IRequest
{
}