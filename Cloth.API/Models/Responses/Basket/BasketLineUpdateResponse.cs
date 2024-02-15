namespace Cloth.API.Models.Responses.Basket;

public class BasketLineUpdateResponse
{
    public Guid BasketLineId { get; set; }
    public Guid SizeId { get; set; }
    public Guid ClothId { get; set; }
    public int Quantity { get; set; }
}