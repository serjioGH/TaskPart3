namespace Cloth.Domain.Entities;

public class OrderLines : Entity
{
    public Guid OrderId { get; set; }

    public Guid ClothId { get; set; }

    public Guid SizeId { get; set; }

    public Order Order { get; set; }

    public Cloth Cloth { get; set; }

    public Size Size { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}