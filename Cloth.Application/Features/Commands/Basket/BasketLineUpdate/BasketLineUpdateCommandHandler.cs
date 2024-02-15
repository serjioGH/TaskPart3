namespace Cloth.Application.Features.Commands.Basket.BasketLineUpdate;

using AutoMapper;
using global::Cloth.Application.Interfaces;
using global::Cloth.Application.Models.Dto.Basket;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class BasketLineUpdateCommandHandler : IRequestHandler<BasketLineUpdateCommand, BasketLineUpdateDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BasketLineUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BasketLineUpdateDto> Handle(BasketLineUpdateCommand request, CancellationToken cancellationToken)
    {
        var basketLine = await _unitOfWork.BasketLines.GetBasketLine(request.BasketLineId);

        _mapper.Map(request, basketLine);

        _unitOfWork.Save();

        var updatedDto = _mapper.Map<BasketLineUpdateDto>(basketLine);

        return updatedDto;
    }
}