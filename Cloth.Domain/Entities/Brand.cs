namespace Cloth.Domain.Entities;

public class Brand : Entity
{
    public string Name { get; set; }

    public ICollection<Cloth> Cloths { get; set; }
}