namespace Cloth.API.Models.Requests.Basket;

using Application.Models.Dto.Basket;

public class BasketLineCreateRequest
{
    public Guid UserId { get; set; }

    public BasketLineDto? BasketLine { get; set; }
}