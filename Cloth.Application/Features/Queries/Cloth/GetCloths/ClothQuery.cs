namespace Cloth.Application.Features.Queries.Cloths.GetCloths;

using Cloth.Application.Models.Dto;
using MediatR;
public record ClothQuery() : IRequest<ClothTask1Dto>
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? Size { get; set; }
    public string? Highlight { get; set; }
}


