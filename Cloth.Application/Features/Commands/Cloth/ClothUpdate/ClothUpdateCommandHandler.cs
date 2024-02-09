using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;
using MediatR;

namespace Cloth.Application.Features.Commands.Cloth.ClothUpdate;

public class ClothUpdateCommandHandler : IRequestHandler<ClothUpdateCommand, UpdateClothDto>
{
    private readonly IClothService _clothService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ClothUpdateCommandHandler(IClothService productService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _clothService = productService ?? throw new ArgumentNullException(nameof(productService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateClothDto> Handle(ClothUpdateCommand command, CancellationToken cancellationToken)
    {
        var cloth = await _clothService.UpdateClothAsync(command);
        var updatedProductDto = _mapper.Map<UpdateClothDto>(cloth);

        return updatedProductDto;
    }
}
