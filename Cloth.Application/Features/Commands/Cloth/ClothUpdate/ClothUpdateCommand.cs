using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Commands.Cloths.ClothUpdate;

public record ClothUpdateCommand(
    Guid Id,
    Guid BrandId,
    string Title,
    decimal Price,
    string Description,
    List<GroupClothDto> Groups,
    List<SizeClothDto> Sizes) : IRequest<UpdateClothDto>;