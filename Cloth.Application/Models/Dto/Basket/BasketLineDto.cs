namespace Cloth.Application.Models.Dto.Basket;

using System;

public class BasketLineDto
{
    public Guid BasketId { get; set; }
    public Guid ClothId { get; set; }
    public Guid SizeId { get; set; }
    public decimal Price { get; set; }
    public string SizeName { get; set; }
    public string ClothName { get; set; }
    public int Quantity { get; set; }
}