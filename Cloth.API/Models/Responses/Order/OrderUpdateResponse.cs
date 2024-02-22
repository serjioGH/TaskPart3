namespace Cloth.API.Models.Responses.Order;

public class OrderUpdateResponse
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public Guid StatusId { get; set; }
}