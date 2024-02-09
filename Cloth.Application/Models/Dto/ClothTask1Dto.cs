namespace Cloth.Application.Models.Dto;

using Cloth.Domain.Entities;
using System.Collections.Generic;

public class ClothTask1Dto
{
    public FilterDto? Filter { get; set; }
    public IEnumerable<Cloth>? Products { get; set; }
}

