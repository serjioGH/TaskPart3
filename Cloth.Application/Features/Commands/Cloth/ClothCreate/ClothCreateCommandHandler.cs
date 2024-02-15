using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Services;
using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Commands.Cloth.ClothCreate;

public class ClothCreateCommandHandler : IRequestHandler<ClothCreateCommand, CreateClothDto>
{
    private readonly IClothService _clothService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ClothCreateCommandHandler(IClothService productService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _clothService = productService ?? throw new ArgumentNullException(nameof(productService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<CreateClothDto> Handle(ClothCreateCommand command, CancellationToken cancellationToken)
    {
        var cloth = await _clothService.CreateCloth(command);

        await _unitOfWork.Cloths.InsertAsync(cloth);
        _unitOfWork.Save();

        var itemDto = _mapper.Map<CreateClothDto>(cloth);

        return itemDto;
    }
}