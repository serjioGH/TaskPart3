namespace Cloth.Application.Features.Commands.Basket.BasketLineCreate;

using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto.Basket;
using Cloth.Domain.Entities;
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

        await _unitOfWork.BasketLines.InsertAsync(basketLine);
        await _unitOfWork.SaveAsync();

        var baskeLineDto = _mapper.Map<BasketLineCreateDto>(basketLine);
        return baskeLineDto;
    }
}