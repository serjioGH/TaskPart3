namespace Cloth.API.Models.Requests.Basket;

public class BasketLineUpdateRequest
{
    public Guid BasketLineId { get; set; }
    public Guid ClothId { get; set; }
    public Guid SizeId { get; set; }
    public int Quantity { get; set; }
}