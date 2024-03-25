namespace Cloth.Domain.Entities;

public class User : Entity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Username { get; set; }

    public bool IsDeactivated { get; set; }

    public Basket Basket { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
}