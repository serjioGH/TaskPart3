namespace Cloth.Application.Models.Dto.Basket;

using System;
using System.Collections.Generic;

public class BasketUpdateDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public List<BasketLineDto>? BasketLines { get; set; }
}