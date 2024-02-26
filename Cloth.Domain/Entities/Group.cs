namespace Cloth.Domain.Entities;

public class Group : Entity
{
    public string Name { get; set; }

    public ICollection<ClothGroup> ClothGroups { get; set; }
}