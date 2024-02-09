namespace Cloth.Domain.Entities;

public class Size : Entity
{
    public string Name { get; set; }
    public ICollection<OrderLines> OrderLines { get; set; }
    public ICollection<BasketLine> BasketLines { get; set; }
    public ICollection<ClothSize> ClothSizes { get; set; }
}
