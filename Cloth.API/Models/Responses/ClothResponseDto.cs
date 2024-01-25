namespace Cloth.API.Models.Responses;

using Cloth.Application.Models;
using Cloth.Domain.Entities;
using System.Collections.Generic;

public class ClothResponseDto
{
    public Filter? Filter { get; set; }
    public IEnumerable<Cloth>? Products { get; set; }
}

