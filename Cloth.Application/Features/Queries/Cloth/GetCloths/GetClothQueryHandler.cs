namespace Cloth.Application.Features.Queries.Cloths.GetCloths;

using Cloth.Application.Extensions;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetClothQueryHandler : IRequestHandler<ClothQuery, ClothTask1Dto>
{
    private readonly IClothService _clothService;
    private readonly ILogger<GetClothQueryHandler> _logger;
    public GetClothQueryHandler(IClothService clothService, ILogger<GetClothQueryHandler> logger)
    {
        _clothService = clothService;
        _logger = logger;
    }

    public async Task<ClothTask1Dto> Handle(ClothQuery request, CancellationToken cancellationToken)
    {
        _logger.LogRequestHandlerMessage(request);
        var result = await _clothService.FilterClothsAsync(request.MinPrice, request.MaxPrice, request.Size, request.Highlight);
        return result;
    }
}

