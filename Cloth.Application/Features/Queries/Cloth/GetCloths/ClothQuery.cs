using Cloth.Application.Models.Dto;

namespace Cloth.Application.Features.Queries.Cloths.GetCloths;

using MediatR;

public record ClothQuery() : IRequest<ClothFilterDto>
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? Size { get; set; }
    public string? Highlight { get; set; }
}