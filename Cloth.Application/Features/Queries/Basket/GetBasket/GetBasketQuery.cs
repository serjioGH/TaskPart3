using Cloth.Application.Models.Dto.Basket;

namespace Cloth.Application.Features.Queries.Basket.GetBasket;

using MediatR;

public record GetBasketQuery(Guid UserId) : IRequest<BasketDetailsDto>
{
    public GetBasketQuery() : this(Guid.Empty)
    {
    }
}