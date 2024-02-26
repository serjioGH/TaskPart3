namespace Cloth.Application.Features.Commands.Basket.BasketLineCreate;

using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto.Basket;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class BasketLineCreateCommandHandler : IRequestHandler<BasketLineCreateCommand, BasketLineCreateDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BasketLineCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BasketLineCreateDto> Handle(BasketLineCreateCommand request, CancellationToken cancellationToken)
    {
        var basket = await _unitOfWork.Baskets.GetBasketByUserIdAsync(request.UserId);
        if (basket.BasketLines.Where(p => p.ClothId == request.BasketLine?.ClothId && p.SizeId == request.BasketLine.SizeId)
            .Count() > 0)
        {
            throw new ArgumentException("Item with that size already in basket!");
        }

        var basketLine = _mapper.Map<BasketLine>(request);
        basketLine.BasketId = basket.Id;
        basketLine.Id = Guid.NewGuid();
        var cloth = await _unitOfWork.Cloths
            .GetClothById(basketLine.ClothId);
        basketLine.Price = cloth.Price;
        await CheckClothSizesAsync(basketLine);

        await _unitOfWork.BasketLines.InsertAsync(basketLine);
        await _unitOfWork.SaveAsync();

        var baskeLineDto = _mapper.Map<BasketLineCreateDto>(basketLine);
        return baskeLineDto;
    }

    private async Task CheckClothSizesAsync(BasketLine newBasketLine)
    {
        var clothSize = await _unitOfWork.ClothSizes
            .GetByCompositKey(newBasketLine.ClothId, newBasketLine.SizeId);

        if (clothSize != null)
        {
            clothSize.QuantityInStock -= newBasketLine.Quantity;

            if (clothSize.QuantityInStock < 0)
            {
                throw new ItemNotFoundException($"Cloth does not have that quantity with this size.");
            }
        }
    }
}