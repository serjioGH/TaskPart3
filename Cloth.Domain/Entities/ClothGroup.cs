namespace Cloth.Domain.Entities;

public class ClothGroup
{
    public Guid ClothId { get; set; }

    public Guid GroupId { get; set; }

    public Cloth Cloth { get; set; }
    public Group Group { get; set; }
}

