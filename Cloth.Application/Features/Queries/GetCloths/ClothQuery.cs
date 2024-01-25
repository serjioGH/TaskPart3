namespace Cloth.Application.Features.Queries.GetCloths;

using Cloth.Application.Models.Dto;
using MediatR;


public record ClothQuery() : IRequest<ClothDto>
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? Size { get; set; }
    public string? Highlight { get; set; }
}


