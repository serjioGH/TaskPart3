namespace Cloth.API.Models.Requests.Order;

public class OrderLineCreateRequest
{
    public Guid ClothId { get; set; }

    public Guid SizeId { get; set; }

    public int Quantity { get; set; }
}