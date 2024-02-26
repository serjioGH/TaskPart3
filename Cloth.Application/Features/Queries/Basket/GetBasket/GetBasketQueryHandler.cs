namespace Cloth.Application.Features.Queries.Basket.GetBasket;

using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto.Basket;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetBasketQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BasketDetailsDto> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await _unitOfWork.Baskets.GetBasketByUserIdAsync(request.UserId);

        var mappedBasket = _mapper.Map<BasketDetailsDto>(basket);

        return mappedBasket;
    }
}