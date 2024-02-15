namespace Cloth.Domain.Entities;

public class ClothSize
{
    public Guid ClothId { get; set; }
    public Guid SizeId { get; set; }
    public Cloth Cloth { get; set; }
    public Size Size { get; set; }
    public int QuantityInStock { get; set; }
}