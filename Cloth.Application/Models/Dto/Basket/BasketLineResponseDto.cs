namespace Cloth.Application.Models.Dto.Basket;

using System;

public class BasketLineResponseDto
{
    public Guid Id { get; set; }

    public Guid BasketId { get; set; }

    public Guid ClothId { get; set; }

    public Guid SizeId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}