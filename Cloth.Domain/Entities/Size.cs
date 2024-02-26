namespace Cloth.Domain.Entities;

using Enumarations;

public class Size : Entity
{
    public Enumarations.ClothSize Name { get; set; }

    public ICollection<OrderLines> OrderLines { get; set; }

    public ICollection<BasketLine> BasketLines { get; set; }

    public ICollection<ClothSize> ClothSizes { get; set; }
}