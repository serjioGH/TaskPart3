namespace Cloth.API.Models.Responses.Order;

public class OrderResponse
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public string Status { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalPrice { get; set; }
}