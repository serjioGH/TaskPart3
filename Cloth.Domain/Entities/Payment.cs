namespace Cloth.Domain.Entities;

public class Payment
{
    public Guid PaymentId { get; set; }

    public Enumarations.Payment PaymentMethod { get; set; }

    public DateTime PaymentDate { get; set; }

    public Order Order { get; set; }
}