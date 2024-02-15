namespace Cloth.Domain.Entities;

public class Role : Entity
{
    public string Name { get; set; }

    public ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
}