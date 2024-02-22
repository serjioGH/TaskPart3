namespace Cloth.Application.Models.Dto;

public class OrderLineCreateDto
{
    public Guid ClothId { get; set; }

    public Guid SizeId { get; set; }

    public int Quantity { get; set; }
}