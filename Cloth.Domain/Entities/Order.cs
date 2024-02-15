namespace Cloth.Domain.Entities;

public class Order : Entity
{
    public Guid StatusId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? PaymentId { get; set; }
    public decimal TotalAmount { get; set; }
    public User User { get; set; }
    public ICollection<OrderLines> OrderLines { get; set; }
    public Payment Payment { get; set; }
    public OrderStatus Status { get; set; }
    public bool IsDeleted { get; set; }
}