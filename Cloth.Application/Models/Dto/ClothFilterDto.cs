namespace Cloth.Application.Models.Dto;

using Cloth.Domain.Entities;
using System.Collections.Generic;

public class ClothFilterDto
{
    public FilterDto? Filter { get; set; }
    public IEnumerable<Cloth>? Cloths { get; set; }
}