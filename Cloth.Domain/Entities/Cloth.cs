namespace Cloth.Domain.Entities;

public class Cloth : Entity
{
    public Guid BrandId { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public ICollection<ClothGroup> ClothGroups { get; set; }

    public ICollection<OrderLines> OrderDetails { get; set; }

    public ICollection<ClothSize> ClothSizes { get; set; }

    public ICollection<BasketLine> BasketLines { get; set; }

    public Brand Brand { get; set; }

    public string Description { get; set; }

    public bool IsDeleted { get; set; }
}