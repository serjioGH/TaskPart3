namespace Cloth.Application.Models.Dto.Basket;

public class BasketLineCreateDto
{
    public Guid BasketLineId { get; set; }

    public Guid BasketId { get; set; }

    public Guid ClothId { get; set; }

    public Guid SizeId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}