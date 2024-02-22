namespace Cloth.API.Models.Requests.Order;

public class OrderUpdateRequest
{
    public Guid Id { get; set; }

    public Guid? StatusId { get; set; }

    public Guid? PaymentId { get; set; }
}