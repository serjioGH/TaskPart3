namespace Cloth.API.Models.Responses;

using Cloth.Application.Models.Dto;
using Cloth.Domain.Entities;
using System.Collections.Generic;

public class ClothResponseDto
{
    public FilterDto? Filter { get; set; }
    public IEnumerable<Cloth>? Products { get; set; }
}

