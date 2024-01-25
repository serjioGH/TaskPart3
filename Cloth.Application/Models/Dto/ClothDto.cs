namespace Cloth.Application.Models.Dto;

using Cloth.Domain.Entities;
using System.Collections.Generic;

public class ClothDto
{
    public FilterDto? Filter { get; set; }
    public IEnumerable<Cloth>? Products { get; set; }
}

