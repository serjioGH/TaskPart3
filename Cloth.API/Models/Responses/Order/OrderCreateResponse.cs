namespace Cloth.API.Models.Responses.Order;

public class OrderCreateResponse
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
