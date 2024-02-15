namespace Cloth.Domain.Entities;

public class BasketLine : Entity
{
    public Guid BasketId { get; set; }
    public Guid ClothId { get; set; }
    public Basket Basket { get; set; }
    public Cloth Cloth { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Guid SizeId { get; set; }
    public Size Size { get; set; }
}