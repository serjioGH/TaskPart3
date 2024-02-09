using AutoMapper;
using MediatR;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;

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

        await _unitOfWork.Cloths.Insert(cloth);
        _unitOfWork.Save();

        var entity = await _unitOfWork.Cloths.GetClothById(cloth.Id);

        var itemDto = _mapper.Map<CreateClothDto>(entity);

        return itemDto;
    }
}
