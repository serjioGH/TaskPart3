namespace Cloth.Domain.Entities;

public class Basket : Entity
{   
    public Guid UserId { get; set; }

    public User User { get; set; }

    public ICollection<BasketLine> BasketLines { get; set; }
}
