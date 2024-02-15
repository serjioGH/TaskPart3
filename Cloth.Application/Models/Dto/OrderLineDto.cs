namespace Cloth.Application.Models.Dto;

public class OrderLineDto
{
    public Guid OrderId { get; set; }
    public Guid ClothId { get; set; }
    public Guid SizeId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? Cloth { get; set; }
    public string? Size { get; set; }
}