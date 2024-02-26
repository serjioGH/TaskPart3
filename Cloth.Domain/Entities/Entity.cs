namespace Cloth.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }

    public DateTime CreatedOn { get; set; }
}