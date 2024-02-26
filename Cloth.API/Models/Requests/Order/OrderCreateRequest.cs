namespace Cloth.API.Models.Requests.Order;

public class OrderCreateRequest
{
    public Guid? StatusId { get; set; }

    public Guid? PaymentId { get; set; }

    public Guid UserId { get; set; }

    public List<OrderLineCreateRequest>? OrderLines { get; set; }
}