namespace Cloth.Application.Features.Queries.Basket.GetBasket;

using Cloth.Application.Models.Dto.Basket;
using MediatR;

public record GetBasketQuery(Guid UserId) : IRequest<BasketDetailsDto>
{
    public GetBasketQuery() : this(Guid.Empty)
    {
    }
}