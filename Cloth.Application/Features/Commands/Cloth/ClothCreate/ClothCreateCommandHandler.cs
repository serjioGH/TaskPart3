namespace Cloth.Application.Features.Commands.Cloths.ClothCreate;

using Application.Models.Dto;
using AutoMapper;
using Domain.Entities;
using Interfaces;
using MediatR;

public class ClothCreateCommandHandler : IRequestHandler<ClothCreateCommand, CreateClothDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ClothCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<CreateClothDto> Handle(ClothCreateCommand command, CancellationToken cancellationToken)
    {
        var cloth = _mapper.Map<Cloth>(command);

        await _unitOfWork.Cloths.InsertAsync(cloth);
        await _unitOfWork.SaveAsync();

        var itemDto = _mapper.Map<CreateClothDto>(cloth);

        return itemDto;
    }
}