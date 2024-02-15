using Cloth.Application.Models.Dto;

namespace Cloth.API.Models.Responses.Cloth;

public class ClothResponseDto
{
    public FilterDto? Filter { get; set; }
    public IEnumerable<ClothDto>? Cloths { get; set; }
}