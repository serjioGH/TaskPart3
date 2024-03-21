namespace Cloth.Application.Features.Queries.Cloth.GetCloth;

using global::Cloth.Application.Models.Dto;

using MediatR;

public class GetClothByIdQuery : IRequest<ClothDto>
{
    public Guid ClothId { get; set; }
}