namespace Cloth.Application.Features.Commands.Basket.BasketLineCreate;

using AutoMapper;
using global::Cloth.Application.Interfaces;
using global::Cloth.Application.Interfaces.Factories;
using global::Cloth.Application.Models.Dto.Basket;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class BasketLineCreateCommandHandler : IRequestHandler<BasketLineCreateCommand, BasketLineCreateDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBasketLineFactory _basketLineFactory;

    public BasketLineCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IBasketLineFactory basketLineFactory)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _basketLineFactory = basketLineFactory ?? throw new ArgumentNullException(nameof(basketLineFactory));
    }

    public async Task<BasketLineCreateDto> Handle(BasketLineCreateCommand request, CancellationToken cancellationToken)
    {
        var basket = await _unitOfWork.Baskets.GetBasketByUserIdAsync(request.UserId);

        var basketLine = _basketLineFactory.CreateBasketLine(request);
        basketLine.BasketId = basket.Id;

        await _unitOfWork.BasketLines.InsertAsync(basketLine);
        _unitOfWork.Save();

        var baskeLineDto = _mapper.Map<BasketLineCreateDto>(basketLine);
        return baskeLineDto;
    }
}