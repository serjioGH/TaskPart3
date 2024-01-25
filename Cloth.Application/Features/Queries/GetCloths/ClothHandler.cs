namespace Cloth.Application.Features.Queries.GetCloths;

using Cloth.Application;
using Cloth.Application.Extensions;
using Cloth.Application.Models.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

public record ClothHandler : IRequestHandler<ClothQuery, ResponseDto>
{
    private readonly IClothService _clothService;
    private readonly ILogger<ClothHandler> _logger;
    public ClothHandler(IClothService clothService, ILogger<ClothHandler> logger)
    {
        _clothService = clothService;
        _logger = logger;
    }

    public async Task<ResponseDto> Handle(ClothQuery request, CancellationToken cancellationToken)
    {
        _logger.LogRequestHandlerMessage(request);
        var result = await _clothService.FilterClothsAsync(request.MinPrice, request.MaxPrice, request.Size, request.Highlight);
        return result;
    }
}

