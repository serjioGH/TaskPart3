namespace Cloth.Application.Models.Dto.Basket;

using System;

public class BasketLineDto
{
    public Guid BasketId { get; set; }

    public Guid ClothId { get; set; }

    public Guid SizeId { get; set; }

    public int Quantity { get; set; }
}