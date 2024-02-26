namespace Cloth.Domain.Entities;

public class OrderStatus : Entity
{
    public Enumarations.OrderStatus Name { get; set; }

    public ICollection<Order> Orders { get; set; }
}