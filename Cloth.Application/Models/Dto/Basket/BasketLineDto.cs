namespace Cloth.Application.Models.Dto.Basket;

using System;
using Domain.Enumarations;

public class BasketLineDto
{
    public Guid BasketId { get; set; }
    public Guid ClothId { get; set; }
    public Guid SizeId { get; set; }
    public decimal Price { get; set; }
    public ClothSize SizeName { get; set; }
    public string ClothName { get; set; }
    public int Quantity { get; set; }
}