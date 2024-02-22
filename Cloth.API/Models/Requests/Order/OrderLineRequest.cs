namespace Cloth.API.Models.Requests.Order;

public class OrderLineRequest
{
    public Guid OrderId { get; set; }

    public Guid ClothId { get; set; }

    public Guid SizeId { get; set; }

    public int Quantity { get; set; }
}