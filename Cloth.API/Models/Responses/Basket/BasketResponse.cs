namespace Cloth.API.Models.Responses.Basket;

using global::Cloth.Application.Models.Dto.Basket;

public class BasketResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public decimal TotalAmount { get; set; }

    public string FullName { get; set; }

    public List<BasketLineResponseDto> BasketLines { get; set; }
}