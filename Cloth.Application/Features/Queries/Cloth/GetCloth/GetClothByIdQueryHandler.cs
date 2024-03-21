namespace Cloth.Application.Features.Queries.Cloth.GetCloth;

using AutoMapper;
using Application.Interfaces;
using Application.Models.Dto;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class GetClothByIdQueryHandler : IRequestHandler<GetClothByIdQuery, ClothDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<GetClothByIdQueryHandler> _logger;

    public GetClothByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetClothByIdQueryHandler> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ClothDto> Handle(GetClothByIdQuery request, CancellationToken cancellationToken)
    {
        var cloth = await _unitOfWork.Cloths.GetClothById(request.ClothId);

        var response = _mapper.Map<ClothDto>(cloth);
        return response;
    }
}