namespace Cloth.Application.Features.Commands.Cloths.ClothCreate;

using Application.Models.Dto;
using MediatR;

public record ClothCreateCommand(
    Guid BrandId,
    string Title,
    decimal Price,
    string Description,
    List<GroupClothDto> Groups,
    List<SizeClothDto> Sizes) : IRequest<CreateClothDto>;