using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Commands.Cloth.ClothCreate;

public record ClothCreateCommand(
    Guid BrandId,
    string Title,
    decimal Price,
    string Description,
    List<GroupClothDto> Groups,
    List<SizeClothDto> Sizes) : IRequest<CreateClothDto>;